using System;

namespace KaffeeMaschine
{
    class Program
    {
        static void Main(string[] args) //               doppelklick auf exe
        {
            /*
                Aufgabe 1: Kaffeemaschine um Kontainer erweitern
                    Jedes Getränk zieht aus den Kontainern etwas ab
                    Wenn nicht mehr genug vorhanden ist wird anstelle des getränks 
                    eine fehlermeldung gezeigt.
                
                Aufgabe 2: Eine Wartungsoption
                    Wenn wartung eingegeben wird werden die Kontainer wieder auf Maximum befüllt

                Aufgabe 3: füllstand wird dem Nutzer als Prozentbalken angezeigt
            */
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
