using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialisierung
{
    class Program
    {
        static void Main()
        {
            DataContainer data = new DataContainer();
            data.NumberA = 50000;
            data.BitB = true;
            data.TextC = "Hallo Welt";

            XmlSerializer serializer = new XmlSerializer(typeof(DataContainer));

            using (var writer = new StreamWriter("data.xml"))
            {
                serializer.Serialize(writer, data);
            }
            
            DataContainer dataFromDisk;

            using (var reader = new StreamReader("data.xml"))
            {
                dataFromDisk = (DataContainer)serializer.Deserialize(reader);
            }

            Console.WriteLine(dataFromDisk.NumberA);
            Console.WriteLine(dataFromDisk.BitB);
            Console.WriteLine(dataFromDisk.TextC);
        }
    }

    public class DataContainer
    {
        public int NumberA;
        public bool BitB;
        public string TextC;
    }

}
