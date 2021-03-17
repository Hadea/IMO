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

            // Methode die zwei zahlen entgegennimmt und alle zahlen zwischen diesen ausgibt
            // übergabe von 2 7, ausgabe 3 4 5 6

            // Methode die eine Zahl entgegennimmt und entsprechend der zahl fibunacci-werte ausgibt
            // übergabe von 5, ausgabe 1 1 2 3 5

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
