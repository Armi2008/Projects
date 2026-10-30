
using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

    public static bool GameOverStarted = false;
    public static bool GameWonStarted = false;

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

        while (!Token.IsCancellationRequested && IsAlive && !GameOverStarted && !GameWonStarted)
        {
            await Task.Delay(50);

            if (GameOverStarted || GameWonStarted || Token.IsCancellationRequested)
                break;

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

        if (!GameOverStarted)
        {
            IsAlive = false;
            Map[Y, X] = "  ";
        }
    }


    public static void GameOver(Player player)
    {
        GameOverStarted = true;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;

        string[] gameOverText =
        {
        @"   _____          __  __ ______    ______      ________ _____  ",
        @"  / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ ",
        @" | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |",
        @"  | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / | |__| | |  _  / ",
        @" | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ ",
        @"  \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\"
    };

        int startY = Math.Max(0, (Console.WindowHeight - gameOverText.Length) / 2);

        for (int i = 0; i < gameOverText.Length; i++)
        {
            int x = Math.Max(0, (Console.WindowWidth - gameOverText[i].Length) / 2);

            Console.SetCursorPosition(x, startY + i);
            Console.WriteLine(gameOverText[i]);

            Thread.Sleep(150);
        }

        Thread.Sleep(1500);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;

        string[] deathText =
        {
        "YOU DIED 💀",
        "",
        "Your adventure has come to an end.",
        "",
        "Press any key to exit..."
        };

        int deathStartY = Math.Max(0, (Console.WindowHeight - deathText.Length) / 2);

        for (int i = 0; i < deathText.Length; i++)
        {
            int x = Math.Max(0, (Console.WindowWidth - deathText[i].Length) / 2);

            Console.SetCursorPosition(x, deathStartY + i);

            if (i == 0)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(deathText[i]);
        }

        Console.ResetColor();

        Console.ReadKey(true);

        Environment.Exit(0);
    }


    public void fightMobs(Player player, string[,] Map)
    {
        if (GameOverStarted)
            return;

        if (player.playerX + 1 == X && player.playerY == Y + 1 ||
            player.playerX - 1 == X && player.playerY == Y - 1 ||
            player.playerX == X + 1 && player.playerY == Y ||
            player.playerX == X && player.playerY == Y + 1 ||
            player.playerX == X && player.playerY == Y - 1 ||
            player.playerX == X && player.playerY == Y)
        {
            Health -= player.attack;

            if (player.shield > 0)
            {
                player.shield -= Damage;
            }
            else if (player.shield <1)
            {
                player.shield = 0;
                player.healthPoints -= Damage;
            }

            if (player.healthPoints <= 0)
            {
                
                GameOverStarted = true;

                playground.startMapIsActive = false;
                playground.secondRoomIsActive = false;
                playground.thirdRoomIsActive = false;
                playground.recoveryRoomIsActive = false;
                playground.traderRoomIsActive = false;

                player.IsAlive = false;

                return;
            }

            playground.ShowInformation(Map);

            if (Health <= 0 && IsAlive)
            {
                IsAlive = false;
                IsDefeated = true;
                Program.CheckGameWon(playground);
                Map[Y, X] = "  ";

                if (!GoldReceived)
                {
                    player.Gold += GoldMob;
                    GoldReceived = true;
                }
            }
        }
    }
}
