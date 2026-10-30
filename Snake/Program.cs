
class Program
{
    public static void Main()
    {
        Snake snake = new Snake();
        Spielfeld spielfeld = new Spielfeld(snake);


        while (snake.Snakelebt)
        {   
            Thread.Sleep(30);
            Console.Clear();
            
            spielfeld.SpielfeldErstellen();
        }

    }
}
