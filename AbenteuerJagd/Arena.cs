using System.Numerics;

public class Arena
{
    public char[,] ArenaMap = new char[20, 60];

    int MidX = (Console.WindowWidth) / 2 + 100;
    int MidY = (Console.WindowHeight) / 2;


    

    public void GenerateArena()
    {
        int width = ArenaMap.GetLength(1);
        int height = ArenaMap.GetLength(0);

        int mitteX = width / 2;
        int mitteY = height / 2;

        double radiusX = width * 0.42;
        double radiusY = height * 0.42;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double abstandX = (x - mitteX) / radiusX;
                double abstandY = (y - mitteY) / radiusY;

                double abstand = abstandX * abstandX + abstandY * abstandY;

                if (abstand >= 0.90 && abstand <= 1.10)
                {
                    ArenaMap[y, x] = '#';
                }
                else
                {
                    ArenaMap[y, x] = ' ';
                }
            }
        }

        ShowArena();
    }
    
    public void ShowArena()
    {
        Console.Clear();
        Console.SetCursorPosition(MidX, MidY);

        for (int y = 0; y < ArenaMap.GetLength(0); y++)
        {
            for (int x = 0; x < ArenaMap.GetLength(1); x++)
            {
                Console.Write(ArenaMap[y, x]);
            }

            Console.WriteLine();
        }
    }
}

