using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    internal class Start
    {
        public static void StartProgramm()
        {
            Console.Clear();

            Console.WriteLine("Willkommen zu Tic Tac Toe !!!\n");
            Console.WriteLine("Drücke eine beliebige Taste zum starten \n");
            Console.ReadKey();
            Console.WriteLine("------------------------------------ \n ");
            Console.WriteLine("'DRÜCKE 1' um das Spiel zu starten und 'DRÜCKE 2' um dir die Spielerklärungen anzusehen.");
            string start = Console.ReadLine();
            if (start == "1") { 
                Console.Write("Programm startet");

                for (int i = 0; i < 6; i++)
                {
                    Thread.Sleep(200);
                    Console.Write(".");
                }

                Thread.Sleep(500);
                Console.Clear();
                Spiel.Eingabe();
           
            } 
            
            else if(start == "2")   
            {
                spielerklärungen.Spielerklärungen();

            }
        }
    }
}
