using System;
using System.Threading;
using System.Threading.Tasks;

public class Mobs
{
    Playground playground;
    public string Name;
    public int Health;
    public int Damage;
    public int X;
    public int Y;

    public int GoldMob;
    public bool IsAlive;
    public bool IsDefeated;

    public bool GoldReceived = false;

    public Mobs(string name, int health, int damage, int x, int y,
            bool isAlive, bool isDefeated, Playground playground, int goldMob)
    {
        Name = name;
        Health = health;
        Damage = damage;
        X = x;
        Y = y;
        IsAlive = isAlive;
        IsDefeated = isDefeated;
        GoldMob = goldMob;
        this.playground = playground;
    }

    public async Task MoveMobs(string[,] Map, Player player, CancellationToken Token)
    {
        Random random = new Random();
        while (!Token.IsCancellationRequested && IsAlive)
        {
            await Task.Delay(50);
            int direction = random.Next(4);
            int newX = X;
            int newY = Y;
            switch (direction)
            {
                case 0:
                    newY--;
                    break;
                case 1:
                    newY++;
                    break;
                case 2:
                    newX--;
                    break;
                case 3:
                    newX++;
                    break;
            }
            if (newX >= 0 &&
                newX < Map.GetLength(1) &&
                newY >= 0 &&
                newY < Map.GetLength(0) &&
                Map[newY, newX] == "  ")
            {
                Map[Y, X] = "  ";
                X = newX;
                Y = newY;
                Map[Y, X] = Name;
            }
            fightMobs(player, Map);
        }
        IsAlive = false;
        Map[Y, X] = "  ";
    }

    public void fightMobs(Player player, string[,] Map)
    {
        if (player.playerX + 1 == X && player.playerY == Y + 1 ||
            player.playerX - 1 == X && player.playerY == Y - 1 ||
            player.playerX == X + 1 && player.playerY == Y ||
            player.playerX == X && player.playerY == Y + 1 ||
            player.playerX == X && player.playerY == Y - 1 ||
            player.playerX == X && player.playerY == Y)
        {
            Health -= player.attack;
            player.healthPoints -= Damage;
            playground.ShowInformation(Map);
            if (Health <= 0 && IsAlive)
            {
                IsAlive = false;
                IsDefeated = true;
                Map[Y, X] = "  ";

                if (!GoldReceived)
                {
                    player.Gold += GoldMob;
                    GoldReceived = true;
                }
            }
            if (player.healthPoints <= 0)
            {
                player.IsAlive = false;
                Console.Clear();
                Console.WriteLine("Game Over!");
            }
        }
    }
}