using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegateZahlen_ConsoleApplication
{
    class Program
    {
        public delegate void Del_zahlen(int zahl);

        // Delegatenbeschreibung, die mit int als Parameter, Methode nutzt,
        // die nichts zurückgeben

        static void Main(string[] args)
        {
            Del_zahlen zahlenVerarbeitung;      // Objekt vom Typ Del_zahlen
                                                // kann also die Adresse von Methoden aufrufen
                                                // die void (int) signiert sind
            zahlenVerarbeitung = new Del_zahlen(Zahlen.verdoppeln);
            // in zahlenVerarbeitung ist jetzt die Aufrufadresse von
            // Zahlen.verdoppeln bekannt

            // kann jetzt aufgerufen werden
            zahlenVerarbeitung(21);
            
             
            ReadLine();
        }

        class Zahlen
        {   // die referenzierte Methode für den Delegaten
            // als wiederverwendbare statics
            public static void verdoppeln (int doppel)
            {
                WriteLine("Das Doppelte von {0} ist {1}", doppel, doppel * 2);
            }
        }
    }
}
