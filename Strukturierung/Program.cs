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
