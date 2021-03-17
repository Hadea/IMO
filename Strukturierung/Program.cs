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


            // Methode die eine Zahl entgegennimmt und entsprechend der zahl fibunacci-werte ausgibt
            // übergabe von 5, ausgabe 1 1 2 3 5
            PrintFibunacci(5);

            // Methode um die Fakultät auszugeben   
            // übergabe 5, ausgabe 120   1 * 2 * 3 * 4 * 5
        }

        static void PrintFibunacci(int AnzahlDerWerte)
        {

            int ausgabeZahl = 1;
            //    1               1
            int alterWert = ausgabeZahl;
            while (ausgabeZahl < 11)
            {
                //                      1
                Console.WriteLine(ausgabeZahl);
                //  2              1            1
                ausgabeZahl = ausgabeZahl + alterWert;
            }

            /* AnzahlDerWerte = 5
             * 
             * A 2
             * B 3
             * ausgabe 5
             * 
             * solange eine bedingung erfüllt ist
             *      ausgabe überschreiben mit  A plus B
             *      ausgabe auf den Bildschirm bringen
             *      A überschreiben mit B
             *      B überschreiben mit ausgabe
             * ende solange
             * 
             */
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
