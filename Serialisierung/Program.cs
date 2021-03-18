using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialisierung
{
    class Program
    {
        static void Main()
        {
            // neuen leeren DataContainer erzeugen und RAM position merken.
            DataContainer data = new DataContainer();
            
            // DataContainer stück für stück füllen
            data.NumberA = 50000;
            data.BitB = true;
            data.TextC = "Hallo Welt";

            // Serializer im RAM erstellen und position merken. Der Serializer wird dabei direkt
            // auf eine Datenstruktur festgelegt, hier der DataContainer.
            XmlSerializer serializer = new XmlSerializer(typeof(DataContainer));

            // Über den StreamWriter holen wir uns schreibzugriff auf die Datei data.xml
            // Das using sorgt dafür das der Dateizugriff auch wieder beendet wird. "Dispose"
            using (var writer = new StreamWriter("data.xml"))
            {
                // Der befehl Serialize schreibt in den StreamWriter den kompletten nach XML konvertierten
                // inhalt des DataContainer.
                serializer.Serialize(writer, data);
            } // auf der schliessenden klammer des using wird der Dateizugriff freigegeben.

            // Eine Variable die den demnächst gelesen DataContainer beinhalten soll
            DataContainer dataFromDisk;

            if (File.Exists("data.xml")) // Überprüfen ob die Datei existiert, denn nur dann können wir lesen ;)
            {
                // Mit dem StreamReader holen wir uns lesezugriff auf die data.xml
                // das using sorgt dafür das der lesezugriff auch wieder beendet wird.
                using (var reader = new StreamReader("data.xml"))
                {
                    // Mit Deserialize lesen wir den gesamten inhalt aus dem StreamReader
                    // das dadurch erzeugte objekt wird im RAM platziert und wir merken uns die Adresse
                    // in dataFromDisk. Da Deserialize mit allen Objekten klar kommen soll gibt es das gelesene
                    // Objekt als "object" zurück, weshalb wir es uminterpretieren müssen zu dem was es vorher war
                    dataFromDisk = (DataContainer)serializer.Deserialize(reader);
                } // beendet den lesezugriff auf die Datei "dispose"

                // ausgeben des inhalts des frisch von der Festplatte gelesenen Objektes.
                Console.WriteLine(dataFromDisk.NumberA);
                Console.WriteLine(dataFromDisk.BitB);
                Console.WriteLine(dataFromDisk.TextC);
            }
        }
    }

    /// <summary>
    /// Der DataContainer repräsentiert die Datenstruktur welche auf die Festplatte geschrieben und auch gelesen werden sollen.
    /// </summary>
    public class DataContainer
    {
        public int NumberA;
        public bool BitB;
        public string TextC;
    }

}
