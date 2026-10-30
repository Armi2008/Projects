public class Player
{
    public int playerX = 40;
    public int playerY = 12;
    public int healthPoints = 10;

    public int attack = 2;
    public int shield = 5;

    public int Gold = 10;
    public int Diamond = 0;

    public bool IsAlive = true;
    public string Pl = "🧙";

    public void moveUp(string[,] Map)
    {
        playerY--;

        if (!collisionCheck(Map))
        {
            playerY++;
        }
    }

    public void moveDown(string[,] Map)
    {
        playerY++;

        if (!collisionCheck(Map))
        {
            playerY--;
        }
    }

    public void moveLeft(string[,] Map)
    {
        playerX--;

        if (!collisionCheck(Map))
        {
            playerX++;
        }
    }

    public void moveRight(string[,] Map)
    {
        playerX++;

        if (!collisionCheck(Map))
        {
            playerX--;
        }
    }

    public bool collisionCheck(string[,] Map)
    {
        int nextX = playerX;
        int nextY = playerY;

        if (nextX < 0 || nextX >= Map.GetLength(1) ||
            nextY < 0 || nextY >= Map.GetLength(0))
        {
            return false;
        }

        string feld = Map[nextY, nextX];

        if (feld == "  " || feld == "🚪")
        {
            return true;
        }

        return false;
    }
}