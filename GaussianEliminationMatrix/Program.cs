using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GaussianEliminationMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anzahl der Zeilen in der Matrix angeben: ");
            int zeilen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Anzahl der Spalten in der Matrix angeben: ");
            int spalten = Convert.ToInt32(Console.ReadLine());

            double[,] input = new double[zeilen, spalten];

            for (int InputZeile = 0; InputZeile < zeilen; InputZeile++)
            {
                for (int InputSpalte = 0; InputSpalte < spalten; InputSpalte++)
                {
                    Console.WriteLine("Zeile " + InputZeile + "  Spalte " + InputSpalte + " Wert:");
                    input[InputZeile, InputSpalte] = Convert.ToDouble(Console.ReadLine());
                }
            }
            
            // Eingabe zur Kontrolle ausgeben
            Console.WriteLine("Eingegebenes Array");
            for (int i = 0; i < zeilen; i++)
            {
                for (int o = 0; o < spalten; o++)
                {
                    Console.Write(Convert.ToString(input[i, o]) + " ");
                }
                Console.WriteLine();
            }

            // Array an RowReduce-Funktion übergeben
            double[,] output = RowReduce(input);


            // Ausgabe von RowReduce in Konsole ausgeben
            Console.WriteLine("Reduziertes Array");
            for (int i = 0; i < zeilen; i++)
            {
                for (int o = 0; o < spalten; o++)
                {
                    Console.Write(Convert.ToString(output[i, o]) + " ");
                }
                Console.WriteLine();
            }

            // Auf Enter warten und Programm schliessen
            Console.ReadLine();
        }

        public static double[,] RowReduce(double[,] n)
        {
            // Ab hier gilt: GLHF
            int IntZeilenGes = n.GetLength(0);
            int IntSpaltenGes = n.GetLength(1);
            Console.WriteLine( "Zeilen: " + IntZeilenGes + " Spalten: " + IntSpaltenGes );
            
            // for-Schleife für Durchlauf nach Spalte
            for (int IntDurchlaufSpalte = 0; IntDurchlaufSpalte < IntSpaltenGes - 1; IntDurchlaufSpalte++)
            {
                // Zeile nach aktueller Spaltennummer auf 1 bringen
                double doubleDivisor = n[IntDurchlaufSpalte, IntDurchlaufSpalte];
                for (int IntSpalte = 0; IntSpalte < IntSpaltenGes; IntSpalte++)
                {
                    n[IntDurchlaufSpalte, IntSpalte] = n[IntDurchlaufSpalte, IntSpalte] / doubleDivisor;
                }

                // Restliche Zeilen auf 0 bringen
                for (int IntZeile = 0; IntZeile < IntZeilenGes; IntZeile++)
                {
                    if (IntZeile != IntDurchlaufSpalte)
                    {
                        double DoubleFactor = n[IntZeile, IntDurchlaufSpalte] * -1;
                        for (int IntSpalte = 0; IntSpalte < IntSpaltenGes; IntSpalte++)
                        {
                            n[IntZeile, IntSpalte] = n[IntZeile, IntSpalte] + n[IntDurchlaufSpalte, IntSpalte] * DoubleFactor;
                        }
                    }
                }
            }

            // Array zurückgeben
            return n;
        }
    }
}
