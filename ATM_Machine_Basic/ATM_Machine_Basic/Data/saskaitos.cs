using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Machine_Basic.Data
{
    class Saskaita : Klientas
    {
        public string SaskaitosNumeris { get; set; }

        public Tranzakcijos Tranzakcijos { get; set; }
        public double SaskaitosLikutis { get; set; }
        public Kortele manoKortele { get; set; }

        public List<Tranzakcijos> pavedimai = new List<Tranzakcijos>();

        public void Israsas()
        {
            foreach (var pavedimai in pavedimai)
            {
                Console.WriteLine("{0}   {1} {2}    {3}", pavedimai.MokejimoPaskirtis, pavedimai.Suma, pavedimai.Valiuta, pavedimai.Laikas);
            }

        }
        public void inestiPinigus(double inesamaSuma, Valiutos valiuta)
        {

            switch (valiuta)
            {
                case Valiutos.EUR:
                    SaskaitosLikutis = SaskaitosLikutis + inesamaSuma;
                    break;
                case Valiutos.USD:
                    SaskaitosLikutis = SaskaitosLikutis + inesamaSuma * 0.883119177;
                    break;
                case Valiutos.GBP:
                    SaskaitosLikutis = SaskaitosLikutis + inesamaSuma * 1.14181931;
                    break;

            }
        }

        public void issimtiPinigus(double isimamaSuma, Valiutos valiuta)
        {
            switch (valiuta)
            {
                case Valiutos.EUR:
                    SaskaitosLikutis = SaskaitosLikutis - isimamaSuma;
                    break;
                case Valiutos.USD:
                    SaskaitosLikutis = SaskaitosLikutis - isimamaSuma * 0.883119177;
                    break;
                case Valiutos.GBP:
                    SaskaitosLikutis = SaskaitosLikutis - isimamaSuma * 1.14181931;
                    break;

            }
        }

    }
}
