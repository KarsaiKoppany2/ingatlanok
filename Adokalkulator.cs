using System;
using System.Collections.Generic;
using System.Text;

namespace ingatlanok
{
    public static class Adokalkulator
    {
        public static double VagyonszerzesiAdo(double arEzerFt) 
        {
            return arEzerFt * 1000 * 0.04;
        }
    }
}
