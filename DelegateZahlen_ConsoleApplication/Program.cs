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
            zahlenVerarbeitung += new Del_zahlen(Zahlen.quadrieren);
            zahlenVerarbeitung += new Del_zahlen(Zahlen.halbieren);     // wichtig! +=
            zahlenVerarbeitung += new Del_zahlen(Zahlen.wurzel);        // darf unten halt nicht double sein
            
            // eine Methode hinzufügen, die noch nicht angelegt ist
            // anonym. ohne, eine Klasse zu bauen, ohne eine statische Methode
            // einfach schnell genutzt werden
            zahlenVerarbeitung += new Del_zahlen((int zahl) => { WriteLine("so, hier nochmal die {0}", zahl); });

            // in zahlenVerarbeitung ist jetzt die Aufrufadresse von
            // Zahlen.verdoppeln bekannt

            // kann jetzt aufgerufen werden
            zahlenVerarbeitung(42);
            ReadLine();
            zahlenVerarbeitung -= new Del_zahlen(Zahlen.halbieren);     // -= nimmt das halbieren wieder weg beim kompletten Aufruf
            zahlenVerarbeitung(42);
             
            ReadLine();
        }

        class Zahlen
        {   // die referenzierte Methode für den Delegaten
            // als wiederverwendbare statics
            public static void verdoppeln (int doppel)
            {
                WriteLine("Das Doppelte von {0} ist {1}", doppel, doppel * 2);
            }

            public static void quadrieren(int quad)
            {
                WriteLine("Quadriert {0} ist {1}", quad, quad * quad);
            }

            public static void halbieren(int halb)
            {
                WriteLine("Das Hälfte von {0} ist {1}", halb, halb / 2);
            }

            public static void wurzel(int wurz)     // muss hier int sein
            {
                WriteLine("Die Wurzel aus {0} ist {1}", wurz, Math.Sqrt(wurz).ToString());
            }
        }
    }
}
