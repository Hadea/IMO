using System;

namespace KaffeeMaschine
{
    class Program
    {
        static void Main(string[] args) //               doppelklick auf exe
        {

            Console.WriteLine("Hallo Nutzer, die Kaffeemaschine ist einsatzbereit!"); //Begrüssung ausgeben

            bool keepRunning = true;
            do
            {

                //Kaffee/Tee Auswahlmenü anzeigen
                Console.WriteLine("Kaffee -> Schöner schwarzer heisser kaffe, junge");
                Console.WriteLine("Tee    -> Schwarzer Tee aus biologischem Anbau");
                Console.WriteLine("Wasser -> Heisses Wasser");
                Console.WriteLine("Abschalten -> Schaltet die Maschine aus");

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
                    case "Abschalten":
                        Console.WriteLine("dann bekommen sie eben nix"); //Getränk ausgeben
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Die Eingabe kenne ich nicht"); // fehler
                        break;
                }
            } while (keepRunning);

            Console.WriteLine("Kaffeemaschine beendet sich");
        }
    }
}
