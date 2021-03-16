using System;
using System.Collections.Generic;

namespace Kontrollstrukturen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verzweigungen

            if (5 < 7) // testet ob eine bedingung nicht falsch ist
            {
                // wenn if ein true ausrechnet
                Console.WriteLine("5 ist kleiner als 7");
            }
            else // else ist optional, muss also nicht benutzt oder geschrieben werden
            {
                // in jedem anderen fall
                Console.WriteLine("5 ist grösser als 7");
            }
            // hier geht es dann weiter

            int zustand = 2;

            switch (zustand)
            {
                case 1:
                    Console.WriteLine("Zustand ist nun auf EINS");
                    break;

                case 2:
                case 3:
                    Console.WriteLine("Zustand ist nun auf ZWEI oder DREI");
                    break;

                default:
                    Console.WriteLine("Zustand ist nun IRGENDEINER");
                    break;
            }


            Stuff zuTesten = Stuff.Charly;

            switch (zuTesten)
            {
                case Stuff.Alpha:
                    break;
                case Stuff.Bravo:
                    break;
                case Stuff.Charly:
                    break;
                case Stuff.Delta:
                    break;
                default:
                    break;
            }

            // Schleifen

            int zaehlerWhile = 0;
            while (zaehlerWhile < 5) // solange bedingung erfüllt ist wird wiederholt
            {
                Console.WriteLine("Aktueller Zählerstand im While ist: " + zaehlerWhile);
                zaehlerWhile++;
            }

            Console.WriteLine("Jetzt kommt das DO");

            do
            {
                // code wird mindestens einmal ausgeführt
                // häufig verwendet in Consolen Apps in Menüs
                Console.WriteLine("Wir sind innerhalb des DO, der zählerWhile ist auf :" + zaehlerWhile);
                zaehlerWhile--;
            } while (zaehlerWhile >= 0); // test ob der code nocheinmal ausgeführt werden soll (wanna see me do it again?)

            Console.WriteLine("for schleifen-demo");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Der Wert in i ist: " + i);
            }

            for (;;) // Zoidberg FOR, eine endlos schleife
            {
                zaehlerWhile++;
                if (zaehlerWhile > 5)
                {
                    break; // beendet die schleife
                }
            }

            Console.WriteLine("Demo für foreach");

            List<int> zahlenListe = new List<int>();
            zahlenListe.Add(5);
            zahlenListe.Add(2);
            zahlenListe.Add(7);

            foreach (int aktuelleZahl in zahlenListe)
            {
                Console.WriteLine("Wert in aktuelleZahl ist: " + aktuelleZahl);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
