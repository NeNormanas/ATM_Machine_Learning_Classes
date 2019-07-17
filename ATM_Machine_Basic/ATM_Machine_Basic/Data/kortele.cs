using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Machine_Basic.Data
{

    enum KortelesTipas
    {
        Visa, MasterCard, Revolut
    }
    class Kortele
    {
        public string KortelesNumeris { get; set; }
        public string CVV { get; set; }
        public KortelesTipas kortelesTipas { get; set; }
        private string PINKodas = "1234";
        public bool ArPINIvestasTeisingai = false;



        public bool ArTeisingasPIN(string IvestasPIN)
        {
            bool taip = PINKodas.Equals(IvestasPIN);
            return taip;
        }
        public void PirmasTeisingasPIN()
        {
            ArPINIvestasTeisingai = true;
        }


        public void ChangePIN(string IvestasPIN)
        {
            PINKodas = IvestasPIN;

        }


    }
}
