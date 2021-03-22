using System;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace KaffeeMaschine
{
    class Program
    {
        static void Main() // doppelklick auf exe
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BoxData));

            byte containerCoffee;
            byte containerWater;
            byte containerTea;

            byte containerCoffeeMax = 200;
            byte containerWaterMax = 200;
            byte containerTeaMax = 200;

            byte progressMaximum = 40;
            string fileName = "Settings.db";

            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.Version = 3;
            builder.DataSource = fileName;
            builder.FailIfMissing = true;

            // TODO: Einlesen
            if (File.Exists(fileName))//Wenn data.xml vorhanden 
            {
                using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
                {
                    connection.Open();
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "select coffeeContainer, waterContainer, teaContainer from SavedSettings;";
                    using (var resultReader = command.ExecuteReader())
                    {
                        resultReader.Read();
                        containerCoffee = resultReader.GetByte(0);// coffeeContainer
                        containerWater = resultReader.GetByte(1);// waterContainer
                        containerTea = resultReader.GetByte(2);// teaContainer
                    }
                }

                /* alte variante mit eine XML datei
                using (var reader = new StreamReader(fileName))//     data.xml einlesen
                {
                    BoxData data = (BoxData)serializer.Deserialize(reader);
                    containerCoffee = data.Coffee;
                    containerTea = data.Tea;
                    containerWater = data.Water;
                }*/
            }
            else //andernfalls
            {
                //     Standardwerte nutzen für ersten start. 
                containerCoffee = 0;
                containerTea = 0;
                containerWater = 0;
            }//ende Wenn

            string logo;

            using (StreamReader fs = new StreamReader("logo.txt"))
            {
                logo = fs.ReadToEnd();
            }// macht automatisch das .Dispose() so dass man es nicht mehr vergessen kann.


            bool keepRunning = true;
            do
            {
                Console.Clear(); //leert den Bildschirm und setzt den cursor nach oben links  (0,0)
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(logo);
                Console.ResetColor();

                int numberOfHashTags = containerCoffee / (containerCoffeeMax / progressMaximum);

                Console.Write("\nKaffee: ");
                drawProgress(numberOfHashTags, progressMaximum);

                Console.Write("\nWasser: ");
                numberOfHashTags = containerWater / (containerWaterMax / progressMaximum);
                drawProgress(numberOfHashTags, progressMaximum);

                Console.Write("\nTee   : ");
                numberOfHashTags = containerTea / (containerTeaMax / progressMaximum);
                drawProgress(numberOfHashTags, progressMaximum);

                //Kaffee/Tee Auswahlmenü anzeigen
                drawMenu();

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
                            displayError("Tee");
                        }

                        if (containerWater < 10)// hab ich genug wasser?
                        {
                            displayError("Wasser");
                            readyForDispense = false;// wenn zu wenig wasser, dann können wir nicht brauen, egal ob genug tee da war
                        }

                        if (readyForDispense)// haben wir nach allen prüfungen immer noch ein OK zum brauen?
                        {
                            containerWater -= 10;
                            containerTea -= 5;
                            dispense(userInput);
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
                            displayError("Wasser");
                        }
                        else
                        {
                            containerWater -= 10;
                            dispense(userInput);//Getränk ausgeben
                        }
                        break;
                    case "Kaffee":
                        if (containerCoffee < 5) // hab ich genug Kaffee?
                        {
                            readyForDispense = false; // wenn zu wenig tee, dann können wir nicht brauen
                            displayError("Kaffee");
                        }

                        if (containerWater < 10)// hab ich genug wasser?
                        {
                            displayError("Wasser");
                            readyForDispense = false;// wenn zu wenig wasser, dann können wir nicht brauen, egal ob genug tee da war
                        }

                        if (readyForDispense)// haben wir nach allen prüfungen immer noch ein OK zum brauen?
                        {
                            containerWater -= 10;
                            containerCoffee -= 5;
                            dispense(userInput);
                        }
                        else
                        {
                            Console.WriteLine("Leider hat eine Prüfung nicht geklappt, bitte wählen sie ein anderes Produkt");
                        }

                        Console.WriteLine("Kaffee wird ausgegeben"); //Getränk ausgeben
                        break;
                    case "Abschalten":
                        Console.WriteLine("Auf Wiedersehen!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Die Eingabe kenne ich nicht"); // fehler
                        break;
                }
            } while (keepRunning);

            Console.Write("Kaffeemaschine speichert ... ");

            //TODO: speichern

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "update SavedSettings set coffeeContainer = $containerCoffee, waterContainer = $containerWater, teaContainer = $containerTea;";
                command.Parameters.AddWithValue("$containerCoffee", containerCoffee);
                command.Parameters.AddWithValue("$containerWater", containerWater);
                command.Parameters.AddWithValue("$containerTea", containerTea);
                command.ExecuteNonQuery();
            }
            /* alter weg mit XML
            using (var writer = new StreamWriter(fileName))// Schreibzugriff auf datei anfordern
            {
                // Werte der Containervariablen in Hilfsobjekt packen
                BoxData data = new BoxData();
                data.Coffee = containerCoffee;
                data.Tea = containerTea;
                data.Water = containerWater;

                // Hilfsobjekt in XML umwandeln und in die datei speichern
                serializer.Serialize(writer, data);
            }
            */
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("erledigt.");
            Console.ResetColor();
            Console.WriteLine("Kaffeemaschine beendet sich");

        }

        private static void displayError(string ContainerName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fehler: nicht genügend inhalt in Container: " + ContainerName);
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        private static void dispense(string userInput)
        {
            Console.Write("Bitte warten ");
            for (int counter = 0; counter < 10; counter++)
            {
                Thread.Sleep(200); // pausiert für 200 Millisekunden
                Console.Write(".");
            }

            Console.WriteLine("\nHier ist ihr " + userInput);
            Thread.Sleep(2000);
        }

        static void drawMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Kaffee -> Schöner schwarzer heisser kaffe, junge");
            Console.WriteLine("Tee    -> Schwarzer Tee aus biologischem Anbau");
            Console.WriteLine("Wasser -> Heisses Wasser");
            Console.WriteLine("Wartung -> Füllt die Container");
            Console.WriteLine("Abschalten -> Schaltet die Maschine aus");
        }

        static void drawProgress(int currentValue, int maximumValue)
        {
            for (int i = 0; i < maximumValue; i++)
            {
                if (i < currentValue)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.Write(" ");
            }

            Console.ResetColor();
        }
    }

    public class BoxData
    {
        public byte Coffee;
        public byte Water;
        public byte Tea;
    }
}
