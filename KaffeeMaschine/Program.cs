using System;

namespace KaffeeMaschine
{
    class Program
    {
        static void Main(string[] args) //               doppelklick auf exe
        {

            Console.WriteLine("Hallo Nutzer, die Kaffeemaschine ist einsatzbereit!"); //Begrüssung ausgeben

            //Kaffee/Tee Auswahlmenü anzeigen
            Console.WriteLine("Kaffee -> Schöner schwarzer heisser kaffe, junge");
            Console.WriteLine("Tee    -> Schwarzer Tee aus biologischem Anbau");
            Console.WriteLine("Wasser -> Heisses Wasser");
            Console.WriteLine("Nix    -> Falls sie Geringverdiener sind, Aus dem Weg!");

            string userInput;
            userInput = Console.ReadLine(); //Nutzereingabe einlesen

            switch (userInput)
            {
                case "Tee":
                    Console.WriteLine("Tee wird ausgegeben"); //Getränk ausgeben
                    break;
                case "Wasser":
                    Console.WriteLine("Wasser wird ausgegeben"); //Getränk ausgeben
                    break;
                case "Kaffee":
                    Console.WriteLine("Kaffee wird ausgegeben"); //Getränk ausgeben
                    break;
                case "Nix":
                    Console.WriteLine("dann bekommen sie eben nix"); //Getränk ausgeben
                    break;
                default:
                    Console.WriteLine("Die Eingabe kenne ich nicht"); // fehler
                    break;
            }

            /*
                if  zum testen
                switch zum testen
                Console.WriteLine(); für ausgaben
                Console.ReadKey(); einen tastendruck
                Console.ReadLine(); zeichen lesen bis zu einem Enter;
            */
            Console.WriteLine("Kaffeemaschine beendet sich");
        }
    }
}
