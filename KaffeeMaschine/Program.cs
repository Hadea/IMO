using System;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace KaffeeMaschine
{
    static class Program
    {
        const byte containerCoffeeMax = 200;
        const byte containerWaterMax = 200;
        const byte containerTeaMax = 200;
        const string fileName = "Settings.db";
        const byte progressMaximum = 40;
        static byte containerCoffee;
        static byte containerWater;
        static byte containerTea;

        static void Main(string[] args) // doppelklick auf exe
        {
            if (args.Length > 0)
            {
                // wenn kommandozeilenparameter angegeben wurden
                processArgs(args); // verarbeiten
                return; // kaffeemaschine nicht hochfahren sondern direkt beenden
            }

            // TODO: Einlesen
            if (File.Exists(fileName))//Wenn Datenbank vorhanden 
            {
                LoadContainerDB();
            }
            else //andernfalls
            {
                //     Standardwerte nutzen für ersten start. 
                containerCoffee = 0;
                containerTea = 0;
                containerWater = 0;
            }//ende Wenn

            string logo;

            using (StreamReader fs = new("logo.txt"))
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


                Console.Write("\nKaffee: ");
                int filledFields = containerCoffee / (containerCoffeeMax / progressMaximum);
                drawProgress(filledFields);

                Console.Write("\nWasser: ");
                filledFields = containerWater / (containerWaterMax / progressMaximum);
                drawProgress(filledFields);

                Console.Write("\nTee   : ");
                filledFields = containerTea / (containerTeaMax / progressMaximum);
                drawProgress(filledFields);

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
            if (!File.Exists(fileName))
            {
                // Datenbank existiert nicht, also neu erzeugen.
                CreateDB();
            }
            SaveContainerDB();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("erledigt.");
            Console.ResetColor();
            Console.WriteLine("Kaffeemaschine beendet sich");

        }

        static void processArgs(string[] args)
        {
            //Hack: nur ein parameter wird ausgewertet, mehr als einer ist ein fehler und druckt die hilfe
            if (args.Length > 1)
            {
                Console.WriteLine("Only one Parameter allowed.");
                args[0] = String.Empty; // leeren des ersten parameter damit die Hilfe im switch gezeigt wird
            }

            switch (args[0])
            {
                case "/reset":
                    Console.WriteLine("Erstelle die Datenbank neu mit Standardwerten");
                    CreateDB();
                    break;
                default:
                    Console.WriteLine(@"
NAME
	KaffeeMaschine

OVERVIEW
	Starts or configures a coffee dispenser.

SYNTAX
	KaffeeMaschine [/reset]

DESCRIPTION:
	This program starts a coffe dispenser where you can choose your favorite drink.
	It will use the ressources (if available) to brew your drink.

PARAMETER
	/?
		Shows this help.

	/reset
		Deletes the database file if it exists and creates a new with standard settings.
		All container will be marked as empty with no favorite drink.
"); //TODO: hilfetext
                    break;
            }
        }

        private static void CreateDB()
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("Lösche alte Datenbank");
                File.Delete(fileName);
            }

            SQLiteConnectionStringBuilder builder = new();
            builder.Version = 3;
            builder.DataSource = fileName;
            builder.FailIfMissing = false; // erstellt die datei bei einem Verbindungsversuch automatisch falls sie nicht da ist

            Console.WriteLine("Erstelle neue Datenbankdatei");
            using (SQLiteConnection connection = new(builder.ToString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;

                Console.Write("Erstelle Tabellen ... ");
                command.CommandText = @"create table recipies (
                    ID tinyint unsigned not null primary key,
                    Name varchar(20) not null unique,
                    CoffeeAmount tinyint not null default 0,
                    CoffeeMultiplier decimal(3, 2) not null default 1,
                    WaterAmount tinyint not null default 0,
                    WaterMultiplier decimal(3, 2) not null default 1,
                    TeaAmount tinyint not null default 0,
                    TeaMultiplier decimal(3, 2) not null default 1,
                    
                    constraint ccRecipies_CoffeeMultiplier check(CoffeeMultiplier between 0.5 and 4),
                    constraint ccRecipies_WaterMultiplier check(WaterMultiplier between 0.5 and 4),
                    constraint ccRecipies_TeaMultiplier check(TeaMultiplier between 0.5 and 4)
                    );
                    create table SavedSettings (
                        coffeeContainer tinyint unsigned not null,
                        waterContainer tinyint unsigned not null,
                        teaContainer tinyint unsigned not null,
                        lastProduct tinyint unsigned null,
                        constraint ccSavedSettings_waterContainerMax check ( waterContainer < 201  ),
                        constraint fkSavedSettings_Recipies foreign key (lastProduct) references Recipies (ID)
                    );";
                command.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("erledigt");
                Console.ResetColor();

                Console.Write("Erstelle Standardinhalte ... ");
                command.CommandText = @"insert into SavedSettings values
                    (0,0,0,null);
                    
                    insert into recipies (Name, CoffeeAmount, WaterAmount, TeaAmount, ID) values
                    ('Kaffee', 5,10,0,1),
                    ('Tee',0,10,3,2),
                    ('Wasser',0,10,0,3)";
                command.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("erledigt");
                Console.ResetColor();
            }
        }

        private static void LoadContainerDB()
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.Version = 3;
            builder.DataSource = fileName;
            builder.FailIfMissing = true;

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
        }

        private static void SaveContainerDB()
        {

            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.Version = 3;
            builder.DataSource = fileName;
            builder.FailIfMissing = true;

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "update SavedSettings set coffeeContainer = $containerCoffee, waterContainer = $containerWater, teaContainer = $containerTea;";
                command.Parameters.AddWithValue("$containerCoffee", containerCoffee);
                command.Parameters.AddWithValue("$containerWater", containerWater);
                command.Parameters.AddWithValue("$containerTea", containerTea);
                //TODO: favorit/letzte auswahl speichern
                command.ExecuteNonQuery();
            }
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

        static void drawProgress(int currentValue)
        {
            for (int i = 0; i < progressMaximum; i++)
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
}
