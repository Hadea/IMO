using System;

namespace CommandoParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Die Parameter sind:");

            foreach (string item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}
