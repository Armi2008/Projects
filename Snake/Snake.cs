using System.Numerics;

class Snake
{
    public int SnakeX;
    public int SnakeY;
    public string symbol = " S ";

    public bool Oben = false;
    public bool unten = false;
    public bool rechts = false;
    public bool links = false;
    public bool Snakelebt = true;

    public void NachOben() 
    {
        SnakeY--;
    }

    public void NachUnten()
    {
        SnakeY++;
    }

    public void NachRechts()
    {
        SnakeX++;
    }

    public void NachLinks()
    {
        SnakeX--;
    }

    public static bool Movement()
    {
        
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.W) 
            { 
                
            }
            if (keyInfo.Key == ConsoleKey.A)
            {

            }
            if (keyInfo.Key == ConsoleKey.S)
            {

            }
            if (keyInfo.Key == ConsoleKey.D)
            {

            }







    }

}