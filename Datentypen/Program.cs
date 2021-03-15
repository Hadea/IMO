using System;
using System.Collections.Generic;

namespace Datentypen
{
    class Program
    {
        static void Main( )
        {
            // Wertetypen

            // Ganze Zahlen
            byte MeinByte; // variable erstellen, standardwert ist 0
            MeinByte = 1; // variable auf 1 stellen.

            bool EinBit; // true(1) oder false (0)
            
            byte NurEinByte; // 0 - 255
            sbyte ByteMitVorzeichen; // -128 - 127

            short ZweiByte; // -32k  - 32k
            ushort ZweiByteOhneVorzeichen; // 0 - 65535

            int VierByte; // +/- 2,14 Milliarden
            uint VierByteOhneVorzeichen; // 0 - 2,29 Milliarden

            Int64 AchtByte; // ca +/- 3 Trilliarden

            // Gebrochene angenäherte Zahlen

            float VierByteMitKomma; // ca 6 stellen
            double AchtByteMitKomma; // ca 15 stellen
            decimal SechzehnByteMitKomma; // ca 30 stellen

            // Referenztypen

            short[] MehrereShorts; // erstellt eine variable für eine Arbeitsspeicheradresse eines Short-Arrays
            MehrereShorts = new short[10]; // erstellt das Short-Array und legt die Position in die Variable

            MehrereShorts[5] = 9987; //springt an die Position des arrays, addiert 5 short-längen oben drauf und schreibt
            Console.Write("Das Array hat eine Länge von ");
            Console.WriteLine(MehrereShorts.Length);


            // Operatoren

            int Alpha = 5;
            int Bravo = 10;

            int Ergebnis = Alpha + Bravo; // Addiert, ergebnis ist dann 15
            Ergebnis = Alpha - Bravo; // Subtrahiert, -5
            Ergebnis = Alpha * Bravo; // Multipliziert, 50
            Ergebnis = Alpha / Bravo; // Dividiert, 0   alles hinter dem komma wird abgeschnitten, nicht gerundet
            Ergebnis = Alpha % Bravo; // Modulo, Dividiert, 5   der rest der Division wird ins ergebnis eingetragen

            float Charly = 5;
            float Delta = 10;
            float ErgebnisMitKomma = Charly / Delta; // Dividiert, 0.5 
        }
    }
}
