using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Machine_Basic.Data
{
    enum Valiutos
    {
        EUR, USD, GBP
    }
    class Tranzakcijos
    {
        public Valiutos Valiuta { get; set; }
        public double Suma { get; set; }
        public string MokejimoPaskirtis { get; set; }
        public DateTime Laikas { get; set; }




    }
}
