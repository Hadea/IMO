using System;

namespace KaffeeMaschine
{
    class Program
    {
        static void Main(string[] args) // doppelklick auf exe
        {
            /*
                Aufgabe 1: Kaffeemaschine um Kontainer erweitern
                    Jedes Getränk zieht aus den Kontainern etwas ab
                    Wenn nicht mehr genug vorhanden ist wird anstelle des getränks 
                    eine fehlermeldung gezeigt.
                
                Aufgabe 2: Eine Wartungsoption
                    Wenn wartung eingegeben wird werden die Kontainer wieder auf Maximum befüllt

                Aufgabe 3: füllstand wird dem Nutzer als Prozentbalken angezeigt

                        byte KaffeKontainer  = 50; // max 200
                        byte Ergebnis = aktuellFüllung / ( MaxFüllstand / MaxProzentBreite )

                        |###########################_________________________|
            */
            byte containerCoffee = 120;
            byte containerWater = 44;
            byte containerTea = 30;
            byte containerCoffeeMax = 200;
            byte containerWaterMax = 200;
            byte containerTeaMax = 200;
            byte progressMaximum = 40;


            Console.Write("Hallo Nutzer,"); //Begrüssung ausgeben
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" die Kaffeemaschine ist einsatzbereit!"); //Begrüssung ausgeben
            Console.ForegroundColor = ConsoleColor.White;
            Console.ResetColor();

            bool keepRunning = true;
            do
            {

                int numberOfHashTags = containerCoffee / (containerCoffeeMax / progressMaximum);

                Console.Write("Kaffee: |");
                for (int i = 0; i < progressMaximum; i++)
                {
                    if (i < numberOfHashTags)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");

                Console.Write("Wasser: |");
                numberOfHashTags = containerWater / (containerWaterMax / progressMaximum);
                for (int i = 0; i < progressMaximum; i++)
                {
                    if (i < numberOfHashTags)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");

                Console.Write("Tee   : |");
                numberOfHashTags = containerTea / (containerTeaMax / progressMaximum);
                for (int i = 0; i < progressMaximum; i++)
                {
                    if (i < numberOfHashTags)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");


                //Kaffee/Tee Auswahlmenü anzeigen
                Console.WriteLine("\n\n");
                Console.WriteLine("Kaffee -> Schöner schwarzer heisser kaffe, junge");
                Console.WriteLine("Tee    -> Schwarzer Tee aus biologischem Anbau");
                Console.WriteLine("Wasser -> Heisses Wasser");
                Console.WriteLine("Wartung -> Füllt die Container");
                Console.WriteLine("Abschalten -> Schaltet die Maschine aus");

                string userInput;
                userInput = Console.ReadLine(); //Nutzereingabe einlesen

                bool readyForDispense = true;
                switch (userInput)
                {
                    case "Wartung":
                        containerWater = containerWaterMax;
                        containerTea = containerTeaMax;
                        containerCoffee = containerCoffeeMax;
                        Console.WriteLine("Wartung durchgeführt, alle Container wieder voll");
                        break;
                    case "Tee":
                        // prinzipiell würde tee gehen, ich schau mal nach
                        if (containerTea < 5) // hab ich genug tee?
                        {
                            readyForDispense = false; // wenn zu wenig tee, dann können wir nicht brauen
                            Console.WriteLine("Nicht genug Tee");
                        }

                        if (containerWater < 10)// hab ich genug wasser?
                        {
                            Console.WriteLine("Nicht genug Wasser");
                            readyForDispense = false;// wenn zu wenig wasser, dann können wir nicht brauen, egal ob genug tee da war
                        }

                        if (readyForDispense)// haben wir nach allen prüfungen immer noch ein OK zum brauen?
                        {
                            containerWater -= 10;
                            containerTea -= 5;
                            Console.WriteLine("Hier ist ihr Tee");
                        }
                        else
                        {
                            Console.WriteLine("Leider hat eine Prüfung nicht geklappt, bitte wählen sie ein anderes Produkt");
                        }

                        /*
                        if (containerTea >= 5 && containerWater >= 10)
                        {
                            containerWater -= 10;
                            containerTea -= 5;
                            Console.WriteLine("Tee wird ausgegeben"); //Getränk ausgeben
                        }
                        else
                        {
                            Console.WriteLine("Nicht genügend ressourcen, bitte was anderes wählen");
                        }*/

                        break;
                    case "Wasser":
                        if (containerWater < 10)
                        {
                            Console.WriteLine("Nicht genug Wasser");
                        }
                        else
                        {
                            Console.WriteLine("Wasser wird ausgegeben"); //Getränk ausgeben
                            containerWater -= 10;
                        }
                        break;
                    case "Kaffee":
                        if (containerCoffee < 5) // hab ich genug Kaffee?
                        {
                            readyForDispense = false; // wenn zu wenig tee, dann können wir nicht brauen
                            Console.WriteLine("Nicht genug Kaffee");
                        }

                        if (containerWater < 10)// hab ich genug wasser?
                        {
                            Console.WriteLine("Nicht genug Wasser");
                            readyForDispense = false;// wenn zu wenig wasser, dann können wir nicht brauen, egal ob genug tee da war
                        }

                        if (readyForDispense)// haben wir nach allen prüfungen immer noch ein OK zum brauen?
                        {
                            containerWater -= 10;
                            containerCoffee -= 5;
                            Console.WriteLine("Hier ist ihr Kaffee");
                        }
                        else
                        {
                            Console.WriteLine("Leider hat eine Prüfung nicht geklappt, bitte wählen sie ein anderes Produkt");
                        }

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
