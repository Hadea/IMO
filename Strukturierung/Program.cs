using System;

namespace Strukturierung
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 5;
            int B = 3;

            int Ergebnis = Addition(A, B);


            // Methode die 3 Zahlen entgegennimmt und deren Produkt zurückgibt
            // übergabe von  2 4 2, rückgabe 16
            Console.WriteLine(MultiplyThree(2, 4, 2));

            // Methode die zwei zahlen entgegennimmt und alle zahlen zwischen diesen ausgibt
            // übergabe von 2 7, ausgabe 3 4 5 6
            PrintNumbersBetween(2, 7);


            // Methode die eine Zahl entgegennimmt und entsprechend der zahl fibonacci-werte ausgibt
            // übergabe von 5, ausgabe 1 1 2 3 5
            PrintFibonacci(60);

            // Methode um die Fakultät auszugeben   
            // übergabe 5, ausgabe 120   1 * 2 * 3 * 4 * 5
            Console.WriteLine("Jetzt kommt fakultät");
            PrintFaculty(5);

            // PreIncrement       ++i zählt eine Variable rauf, gibt den neuen wert zurück
            // parameter 5, rückgabe 6, ausgabe 6

            int rueckgabe = PreIncrement(5);
            Console.WriteLine(rueckgabe);

            // PostIncrement      i++  zählt eine Variable rauf, aber gibt den alten wert zurück
            // parameter 5, rückgabewert 5, ausgabe 6

            rueckgabe = PostIncrement(5);
            Console.WriteLine(rueckgabe);


            int zaehler = 0;
            int[] zahlenArray = new int[10];

            while (zaehler < zahlenArray.Length)
                Console.WriteLine(zahlenArray[zaehler++] );

        }

        static int PostIncrement(int v)
        {
            v = v + 1;
            Console.WriteLine(v);
            return v - 1;
        }

        static int PreIncrement(int v)
        {
            v = v + 1;
            Console.WriteLine(v);
            return v;
        }

        static void PrintFaculty(int v)
        {

            int ergebnis = 1;
            for (int counter = 1; counter <= v; counter++)
            {
                //Console.WriteLine("Multipliziere {0} und {1}", ergebnis,counter);
                ergebnis *= counter;
            }

            Console.WriteLine(ergebnis);
        }

        /// <summary>
        /// Gibt die gewünschte anzahl an fibunacci ziffern aus
        /// </summary>
        /// <param name="AnzahlDerWerte">Die anzahl der Ziffern die ausgegeben werden sollen</param>
        static void PrintFibonacci(byte AnzahlDerWerte) // 0 < AnzahlDerWerte < 47
        {
            if (AnzahlDerWerte == 0)
            {
                return;
            }

            if (AnzahlDerWerte > 46)
            {
                return;
            }

            int A = 0;// A 2
            int B = 1;// B 3
            int sum;// ausgabe 5
            Console.WriteLine("1 ");

            while (AnzahlDerWerte > 1)// solange eine bedingung erfüllt ist
            {
                sum = A + B;//      ausgabe überschreiben mit  A plus B
                Console.WriteLine(sum + " "); //      ausgabe auf den Bildschirm bringen
                A = B; //      A überschreiben mit B
                B = sum; //      B überschreiben mit ausgabe
                AnzahlDerWerte--;
            } // ende solange

            // [‎17.‎03.‎2021 14:31] Adam Brodowy: 
            //int number1 = 0;
            //int number2 = 1;
            //int number3;
            //int i;

            //number3 = number1 + number2;
            //Console.Write(number1 + " " + number2 + " ");

            //for (i = 2; i < 6; ++i)
            //{
            //    number3 = number1 + number2;
            //    Console.Write(number3 + " ");
            //    number1 = number2;
            //    number2 = number3;
            //}
        }

        static void PrintNumbersBetween(int Anfang, int Ende)
        {
            for (int count = Anfang + 1; count < Ende; count++)
            {
                Console.WriteLine(count);
            }

            //Anfang++;
            //while ( Anfang < Ende)
            //{
            //    Console.WriteLine(Anfang);
            //    Anfang++;
            //}
        }

        static int MultiplyThree(int Alpha, int Bravo, int Charly)
        {
            return Alpha * Bravo * Charly;
        }

        static int Addition(int ersterWert, int zweiterWert)
        {
            int rueckgabe;
            rueckgabe = ersterWert + zweiterWert;

            return rueckgabe;
        }

        static void KeineRueckgabeKeineParameter()
        { }

        static bool RueckgabeOhneParameter()
        {
            return false;
        }

        static int RueckgabeUndParameter(short ersterParameter)
        {
            return 12;
        }

        static void KeineRueckgabeMitParameter(double ersterParameter)
        { }
    }
}
