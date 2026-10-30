
namespace TicTacToe
{
    internal class spielerklärungen
    {
        public static void Spielerklärungen() 
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 TIC TAC TOE");
            Console.WriteLine("              SPIEL TUTORIAL");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Willkommen beim Tic Tac Toe Tutorial!");
            Console.WriteLine();

            Console.WriteLine("In diesem Tutorial lernst du Schritt für Schritt:");
            Console.WriteLine();
            Console.WriteLine("- Wie das Spielfeld funktioniert");
            Console.WriteLine("- Wie du deine Züge machst");
            Console.WriteLine("- Welche Regeln gelten");
            Console.WriteLine("- Wie du gewinnen kannst");
            Console.WriteLine();

            Console.WriteLine("Drücke eine Taste um zu starten...");
            Console.ReadKey();



            // SCHRITT 1
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 1");
            Console.WriteLine("              DAS SPIELFELD");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Tic Tac Toe wird auf einem 3x3 Spielfeld gespielt.");
            Console.WriteLine();

            Console.WriteLine("Das Spielfeld sieht am Anfang so aus:");
            Console.WriteLine();

            Console.WriteLine("       1   2   3");
            Console.WriteLine();

            Console.WriteLine("   ┌───┬───┬───┐");
            Console.WriteLine("1  │   │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("2  │   │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("3  │   │   │   │");
            Console.WriteLine("   └───┴───┴───┘");

            Console.WriteLine();

            Console.WriteLine("Die Zahlen oben und links zeigen die Positionen.");
            Console.WriteLine("Jedes Feld kann nur einmal benutzt werden.");

            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste um weiterzumachen...");
            Console.ReadKey();



            // SCHRITT 2
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 2");
            Console.WriteLine("              SPIELER UND ZEICHEN");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Es gibt zwei Spieler:");
            Console.WriteLine();

            Console.WriteLine("Spieler 1 spielt mit X.");
            Console.WriteLine("Spieler 2 spielt mit O.");
            Console.WriteLine();

            Console.WriteLine("Das Spiel speichert intern:");
            Console.WriteLine();
            Console.WriteLine("1 = X (Spieler 1)");
            Console.WriteLine("2 = O (Spieler 2)");
            Console.WriteLine("0 = freies Feld");

            Console.WriteLine();

            Console.WriteLine("Beispiel:");
            Console.WriteLine();

            Console.WriteLine("       1   2   3");
            Console.WriteLine();

            Console.WriteLine("   ┌───┬───┬───┐");
            Console.WriteLine("1  │ X │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("2  │   │ O │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("3  │   │   │   │");
            Console.WriteLine("   └───┴───┴───┘");

            Console.WriteLine();

            Console.WriteLine("Spieler 1 hat oben links gesetzt.");
            Console.WriteLine("Spieler 2 hat die Mitte gewählt.");

            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste um weiterzumachen...");
            Console.ReadKey();



            // SCHRITT 3
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 3");
            Console.WriteLine("              EINEN ZUG MACHEN");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Um ein Feld auszuwählen brauchst du:");
            Console.WriteLine();

            Console.WriteLine("1. Die Zeile");
            Console.WriteLine("2. Die Spalte");

            Console.WriteLine();

            Console.WriteLine("Beispiel:");
            Console.WriteLine();

            Console.WriteLine("Du möchtest oben rechts ein X setzen.");

            Console.WriteLine();

            Console.WriteLine("Eingabe:");
            Console.WriteLine("Zeile: 1");
            Console.WriteLine("Spalte: 3");

            Console.WriteLine();

            Console.WriteLine("Das Spielfeld sieht danach so aus:");

            Console.WriteLine();

            Console.WriteLine("       1   2   3");
            Console.WriteLine();

            Console.WriteLine("   ┌───┬───┬───┐");
            Console.WriteLine("1  │   │   │ X │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("2  │   │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("3  │   │   │   │");
            Console.WriteLine("   └───┴───┴───┘");

            Console.WriteLine();

            Console.WriteLine("Jetzt ist dieses Feld für den anderen Spieler gesperrt.");

            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste um weiterzumachen...");
            Console.ReadKey();



            // SCHRITT 4
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 4");
            Console.WriteLine("                 GEWINNEN");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Das Ziel ist es, drei eigene Zeichen");
            Console.WriteLine("in eine Reihe zu bekommen.");

            Console.WriteLine();

            Console.WriteLine("Möglichkeiten:");
            Console.WriteLine();

            Console.WriteLine("- Waagerecht");
            Console.WriteLine("- Senkrecht");
            Console.WriteLine("- Diagonal");

            Console.WriteLine();

            Console.WriteLine("Beispiel für einen Sieg von Spieler 1:");

            Console.WriteLine();

            Console.WriteLine("       1   2   3");
            Console.WriteLine();

            Console.WriteLine("   ┌───┬───┬───┐");
            Console.WriteLine("1  │ X │ X │ X │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("2  │ O │ O │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("3  │   │   │   │");
            Console.WriteLine("   └───┴───┴───┘");

            Console.WriteLine();

            Console.WriteLine("Spieler 1 gewinnt, weil drei X nebeneinander stehen.");

            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste um weiterzumachen...");
            Console.ReadKey();



            // SCHRITT 5
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 5");
            Console.WriteLine("                 REGELN");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Regel 1:");
            Console.WriteLine("Ein Feld darf nicht doppelt benutzt werden.");

            Console.WriteLine();

            Console.WriteLine("Beispiel:");

            Console.WriteLine();

            Console.WriteLine("   ┌───┬───┬───┐");
            Console.WriteLine("1  │ X │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("2  │   │   │   │");
            Console.WriteLine("   ├───┼───┼───┤");
            Console.WriteLine("3  │   │   │   │");
            Console.WriteLine("   └───┴───┴───┘");

            Console.WriteLine();

            Console.WriteLine("Wenn Spieler 2 versucht dort ein O zu setzen:");
            Console.WriteLine("kommt eine Fehlermeldung.");

            Console.WriteLine();

            Console.WriteLine("Regel 2:");
            Console.WriteLine("Nur Zeilen und Spalten von 1 bis 3 sind erlaubt.");

            Console.WriteLine();

            Console.WriteLine("Falsche Eingabe:");
            Console.WriteLine("Zeile: 5");
            Console.WriteLine("Spalte: 8");

            Console.WriteLine();

            Console.WriteLine("Dieses Feld existiert nicht.");

            Console.WriteLine();
            Console.WriteLine("Drücke eine Taste um weiterzumachen...");
            Console.ReadKey();



            // SCHRITT 6
            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine("                  SCHRITT 6");
            Console.WriteLine("                SPIELENDE");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.WriteLine("Das Spiel endet wenn:");
            Console.WriteLine();

            Console.WriteLine("- Spieler 1 drei X in einer Reihe hat.");
            Console.WriteLine("- Spieler 2 drei O in einer Reihe hat.");
            Console.WriteLine("- Alle Felder belegt sind.");

            Console.WriteLine();

            Console.WriteLine("Wenn niemand gewinnt:");
            Console.WriteLine("endet das Spiel unentschieden.");

            Console.WriteLine();

            Console.WriteLine("==================================================");
            Console.WriteLine("             TUTORIAL BEENDET");
            Console.WriteLine("==================================================");

            Console.WriteLine();

            Console.WriteLine("Du kennst jetzt alle Regeln.");
            Console.WriteLine("Viel Spaß beim Spielen! \n\n\n");
            Console.WriteLine("Drücke eine beliebige Taste um das Spiel zu starten.");
            Console.ReadKey();
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
    }
}
