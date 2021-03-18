using System;
using System.Collections.Generic;

namespace Datentypen
{
    class Program
    {
        static void Main()
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
            uint VierByteOhneVorzeichen; // 0 - 4,29 Milliarden

            Int64 AchtByte; // ca +/- 3 Trilliarden

            // Enumerationen

            ApplicationState Status; // erstellt eine Variable vom typ des Enums
            Status = ApplicationState.StartingUp;
            Status = ApplicationState.ShuttingDown;

            Console.Write("Enum-Wert:");
            Console.WriteLine(Status);

            // interpretiert den Arbeitspeicher des Enum als Int und speichert
            // eine Kopie des wertes in einer neuen Variable
            int StatusAlsZahl = (int)Status;

            Console.Write("Enum-Wert als Zahl:");
            Console.WriteLine(StatusAlsZahl);


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

            // Zeichenfolgen

            char Buchstabe; // 2 Byte "UTF-16"
            Buchstabe = 'Z';
            Console.WriteLine(Buchstabe); // Gibt Z aus
            Console.WriteLine((byte)Buchstabe); // gibt 90 aus (ASCII-Tabelle)


            string Text;
            Text = "Viele Worte";
            Console.WriteLine(Text); // gibt Viele Worte aus
            Console.WriteLine(Text[6]); // gibt W aus

            Console.WriteLine($"text mit platzhalter > {Buchstabe} <"); // $ schaltet in den modus das geschweifte klammern quellcode enthalten können

            Console.WriteLine(@"Das Enterzeichen macht man mit \n"); // @ schaltet alle befehle aus und nutzt den text so wie er ist

            // spezielle möglichkeit im Write und WriteLine. Ist ähnlich dem PrintF aus C.
            Console.WriteLine("Werte sind: {0} {2} {1}", Buchstabe, 22, Text);


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

            // operatoren für bool

            bool ergebnis = false || true; // or
            // 1. linker wert wird überprüft ob er true ist, falls ja steht das ergebnis auf true
            // 2. rechter wert wird überprüft ob er true ist, falls ja steht das ergebnis auf true
            ergebnis = true && false; // and
            // sollte der erste wert bereits false sein steht das ergebnis fest auf false
            
            // wenn and und or gemischt verwendet werden immer klammern verwenden

            int test = 20;

            //   false      &&    (   true )
            if (test < 20 && (test > 2 || test % 5 == 0))
            {

            }

            // Kurzschreibweisen für operatoren


            Ergebnis += Alpha; // Entspricht Ergebnis = Ergebnis + Alpha;

            Console.WriteLine("Ausgabe der Inhalte");
            Ergebnis = 5;
            int Rueckgabe = Ergebnis;
            Console.WriteLine("Ergebnis: " + Ergebnis + " Rückgabe: " + Rueckgabe + " Ursprungswerte");
            Rueckgabe = Ergebnis++; // Entspricht Ergebnis = Ergebnis + 1; Gibt den alten wert zurück
            Console.WriteLine("Ergebnis: " + Ergebnis + " Rückgabe: " + Rueckgabe + " nach postincrement");
            Rueckgabe = ++Ergebnis; // Entspricht Ergebnis = Ergebnis + 1; Gibt den neuen wert zurück
            Console.WriteLine("Ergebnis: " + Ergebnis + " Rückgabe: " + Rueckgabe + " nach preincrement");


            int Uebung = 5;
            Uebung++;
            Console.WriteLine(Uebung); // ausgabe 6
            Console.WriteLine(Uebung++); // ausgabe 6

            Uebung = 10;
            // Uebung 12          11    + 11
            Console.WriteLine(++Uebung + Uebung++); // ausgabe 22, Uebung ist danach 12

            int A = 5;
            int B = 7;
            Console.WriteLine(A++ + --B); // ausgabe 11, A und B sind danach 6

            A = 5;
            B = 7;

            // A=5 B=8          8  /   4
            Console.WriteLine(++B / --A); // ausgabe 2

            //                 1  +  7
            Console.WriteLine(--B / A++ + B++); // ausgabe 8


            A = 5;
            B = 7;
            Console.WriteLine( $" Das Ergebnis ist : {( (float)A / B ).ToString("0.00") } ");
            /*
            1. klammern auflösen,
            1.1 A auslesen und zu float konvertieren
            1.2 B auslesen
            1.3 B implizit zu float konvertieren da teilen erfordert das beide werte
                  den gleichen datentypen haben
            1.4 Divisionsfunktion ausführen mit den beiden float-werten 5.0f und 7.0f
            1.5 Rückgabe der Divisionsfunktion wird empfangen
            2   Auf dem float wird die methode ToString() gestartet welche den float über die
                ASCII-Tabelle in einen string verwandelt.
            2.1 Der string wird zurechtgeschnitten anhand des Parameterstrings "0.00"
                welches besagt das zwar alle stellen vor, aber nur 2 stellen nach dem komma gezeigt
                werden sollen.
            3.  Geschweifte klammern werden aufgelöst und der Text der berechnung und der statische
                text werden in einen neuen string kopiert
            4.  der gesamte text wird über die methode writeline ausgegeben
            */
        }
    }
}
