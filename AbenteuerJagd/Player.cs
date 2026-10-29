public class Player
{
    public int playerX = 40;
    public int playerY = 12;
    public int healthPoints = 1000;

    public int attack = 100;
    public int shield = 0;

    public int Gold = 0;

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