using System;

namespace TicTacToe
{
    internal class Spiel
    {
        public static void Eingabe()
        {
            bool unentschieden = false;


            int[,] tabelle = {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 } };

            while (true)
            {
                Console.Clear();

                // Spielfeld anzeigen
                Console.WriteLine("       1   2   3");
                Console.WriteLine();

                Console.WriteLine("   ┌───┬───┬───┐");

                for (int i = 0; i < 3; i++)
                {
                    Console.Write((i + 1) + "  │");

                    for (int j = 0; j < 3; j++)
                    {
                        if (tabelle[i, j] == 0)
                        {
                            Console.Write("   │");
                        }
                        else if (tabelle[i, j] == 1)
                        {
                            Console.Write(" X │");
                        }
                        else if (tabelle[i, j] == 2)
                        {
                            Console.Write(" O │");
                        }
                    }

                    Console.WriteLine();

                    if (i < 2)
                    {
                        Console.WriteLine("   ├───┼───┼───┤");
                    }
                }

                Console.WriteLine("   └───┴───┴───┘");


                // Spieler 1
                while (true)
                {
                    Console.WriteLine("Spieler 1:");

                    Console.Write("In welcher Zeile möchtest du deine 1 setzen: ");
                    int zeileSP1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("In welcher Spalte möchtest du deine 1 setzen: ");
                    int spalteSP1 = Convert.ToInt32(Console.ReadLine());


                    if (tabelle[zeileSP1 - 1, spalteSP1 - 1] == 0)
                    {
                        tabelle[zeileSP1 - 1, spalteSP1 - 1] = 1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dieses Feld ist bereits belegt!");
                    }
                }



                Console.Clear();

                // Spielfeld anzeigen
                Console.WriteLine("   1   2   3");
                Console.WriteLine();

                Console.WriteLine("   ┌───┬───┬───┐");

                for (int i = 0; i < 3; i++)
                {
                    Console.Write((i + 1) + "  │");

                    for (int j = 0; j < 3; j++)
                    {
                        if (tabelle[i, j] == 0)
                        {
                            Console.Write("   │");
                        }
                        else if (tabelle[i, j] == 1)
                        {
                            Console.Write(" X │");
                        }
                        else if (tabelle[i, j] == 2)
                        {
                            Console.Write(" O │");
                        }
                    }

                    Console.WriteLine();

                    if (i < 2)
                    {
                        Console.WriteLine("   ├───┼───┼───┤");
                    }
                }

                Console.WriteLine("   └───┴───┴───┘");

                if (

                    (tabelle[0, 0] == 1 && tabelle[0, 1] == 1 && tabelle[0, 2] == 1) ||
                    (tabelle[1, 0] == 1 && tabelle[1, 1] == 1 && tabelle[1, 2] == 1) ||
                    (tabelle[2, 0] == 1 && tabelle[2, 1] == 1 && tabelle[2, 2] == 1) ||

                    (tabelle[0, 0] == 1 && tabelle[1, 0] == 1 && tabelle[2, 0] == 1) ||
                    (tabelle[0, 1] == 1 && tabelle[1, 1] == 1 && tabelle[2, 1] == 1) ||
                    (tabelle[0, 2] == 1 && tabelle[1, 2] == 1 && tabelle[2, 2] == 1) ||

                    (tabelle[0, 0] == 1 && tabelle[1, 1] == 1 && tabelle[2, 2] == 1) ||
                    (tabelle[0, 2] == 1 && tabelle[1, 1] == 1 && tabelle[2, 0] == 1)

                   )


                {

                    Console.Clear();
                    Console.WriteLine("Spieler 1 hat gewonnen!");
                    break;

                }


                // Spieler 2
                while (true)
                {
                    Console.WriteLine("Spieler 2:");

                    Console.Write("In welcher Zeile möchtest du deine 2 setzen: ");
                    int zeileSP2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("In welcher Spalte möchtest du deine 2 setzen: ");
                    int spalteSP2 = Convert.ToInt32(Console.ReadLine());


                    if (tabelle[zeileSP2 - 1, spalteSP2 - 1] == 0)
                    {
                        tabelle[zeileSP2 - 1, spalteSP2 - 1] = 2;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Dieses Feld ist bereits belegt!");
                    }


                }




                if (
                    (tabelle[0, 0] == 2 && tabelle[0, 1] == 2 && tabelle[0, 2] == 2) ||
                    (tabelle[1, 0] == 2 && tabelle[1, 1] == 2 && tabelle[1, 2] == 2) ||
                    (tabelle[2, 0] == 2 && tabelle[2, 1] == 2 && tabelle[2, 2] == 2) ||

                    (tabelle[0, 0] == 2 && tabelle[1, 0] == 2 && tabelle[2, 0] == 2) ||
                    (tabelle[0, 1] == 2 && tabelle[1, 1] == 2 && tabelle[2, 1] == 2) ||
                    (tabelle[0, 2] == 2 && tabelle[1, 2] == 2 && tabelle[2, 2] == 2) ||

                    (tabelle[0, 0] == 2 && tabelle[1, 1] == 2 && tabelle[2, 2] == 2) ||
                    (tabelle[0, 2] == 2 && tabelle[1, 1] == 2 && tabelle[2, 0] == 2)
                    )

                {

                    Console.Clear();
                    Console.WriteLine("Spieler 2 hat gewonnen!");
                    break;
                }
                if (
                    (tabelle[0, 0] != 0 && tabelle[0, 1] != 0 && tabelle[0, 2] != 0) &&
                    (tabelle[1, 0] != 0 && tabelle[1, 1] != 0 && tabelle[1, 2] != 0) &&
                    (tabelle[2, 0] != 0 && tabelle[2, 1] != 0 && tabelle[2, 2] != 0) 
                    )

                { 
                    unentschieden = true;

                }

                if (unentschieden == true) 
                { 
                    Console.Clear(); 
                    Console.WriteLine("Unentschieden!");
                    break;
                }




                }
        }
    }
}