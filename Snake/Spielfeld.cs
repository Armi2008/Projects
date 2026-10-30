
    class Spielfeld
    {
        Snake snake;

        public Spielfeld(Snake snake)
        {
            this.snake = snake;
        
        }

        public string[,] feld = new string[20, 20];

            public void SpielfeldErstellen()
            {
                Console.Clear();
                for (int y = 0; y < feld.GetLength(0); y++)
                {
                    for (int x = 0; x < feld.GetLength(1); x++)
                    {

                        if (y == 0 || x == 0 || y == 19 || x == 19) 
                        { 
                            feld[y, x] = " # ";
                        }

                        else if (x == feld.GetLength(1) / 2 && y == feld.GetLength(0) /2)
                        { 
                            feld[y, x] = snake.symbol;
                        }

                        

                        else
                        { 
                            feld[y, x] = "   ";
                        }

                    }
                }

                int spielfeldHoehe = feld.GetLength(1);
                int spielfeldWeite = feld.GetLength(0);


                for (int y = 0; y < spielfeldHoehe; y++)
                {
                    string output = "";

                    for (int x = 0; x < spielfeldWeite; x++)
                    {
                        output += feld[y, x];
                        
                    }
                    Console.Write(output);
                    Console.WriteLine();
                }
            }
    }

