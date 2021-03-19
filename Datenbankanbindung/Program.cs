using System;
using System.Data.SQLite;

namespace Datenbankanbindung
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.Version = 3;
            builder.DataSource = "Settings.db";
            builder.FailIfMissing = true;

            byte coffee;
            byte water;
            byte tea;

            using (SQLiteConnection connection = new SQLiteConnection(builder.ToString()))
            {
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "select coffeeContainer, waterContainer, teaContainer from SavedSettings;";
                using (var resultReader = command.ExecuteReader())
                {
                    resultReader.Read();
                    coffee = resultReader.GetByte(0);// coffeeContainer
                    water = resultReader.GetByte(1);// waterContainer
                    tea = resultReader.GetByte(2);// teaContainer
                }
            }

            Console.WriteLine("Kaffeestand: " + coffee);
            Console.WriteLine("Wasserstand: " + water);
            Console.WriteLine("Teestand   : " + tea);

        }
    }
}
