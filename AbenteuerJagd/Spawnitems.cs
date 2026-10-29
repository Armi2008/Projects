public class SpawnItems
{
    Playground playground;
    public string Name;
    public int AttackBoost;
    public int ShieldBoost;
    public int HealthBoost;
    public int X;
    public int Y;

    public SpawnItems(string name, int attackBoost, int shieldBoost, int healthBoost, int x, int y, Playground playground)
    {
        Name = name;
        AttackBoost = attackBoost;
        ShieldBoost = shieldBoost;
        HealthBoost = healthBoost;
        X = x;
        Y = y;
        this.playground = playground;
    }

    public void CollectItem(Player player, string[,] Map)
    {
        if (player.playerX == X + 1 && player.playerY == Y ||
            player.playerX == X && player.playerY == Y + 1 ||
            player.playerX == X - 1 && player.playerY == Y ||
            player.playerX == X && player.playerY == Y - 1 ||
            player.playerX == X + 1 && player.playerY == Y + 1 ||
            player.playerX == X - 1 && player.playerY == Y + 1 ||
            player.playerX == X + 1 && player.playerY == Y - 1 ||
            player.playerX == X - 1 && player.playerY == Y - 1)
        {
            Map[Y, X] = "  ";
            player.attack += AttackBoost;
            player.shield += ShieldBoost;
            player.healthPoints += HealthBoost;
        }
    }
}
