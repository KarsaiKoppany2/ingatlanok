using System;
using System.Collections.Generic;
using System.Text;

namespace ingatlanok
{
    public class Ingatlan
    {
        private int alapteruletM2;
        private int arEzerFt;
        private static int osszesRegisztraltIngatlan = 0;
        public string Azonosito { get; set; }
        public string Cim { get; set; }
        public string Kategoria { get; set; }
        public int AlapteruletM2
        {
            get { return alapteruletM2; }
            set 
            {
                if (value < 10) alapteruletM2 = 10;
                else alapteruletM2 = value;
            }
        }
        public int ArEzerFt
        {
            get { return arEzerFt; }
            set
            {
                if (value < 0) arEzerFt = 0;
                else arEzerFt = value;
            }
        }
        public static int OsszesRegisztraltIngatlan { get { return osszesRegisztraltIngatlan; } }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2) :this(azonosito, cim, kategoria, alapteruletM2, alapteruletM2 * 500) { }
        public Ingatlan(string azonosito, string cim, string kategoria, int alapteruletM2, int arEzerFt) 
        {
            Azonosito = azonosito;
            Cim = cim;
            Kategoria = kategoria;
            AlapteruletM2 = alapteruletM2;
            ArEzerFt = arEzerFt;
            osszesRegisztraltIngatlan++;
        }
    }
}
