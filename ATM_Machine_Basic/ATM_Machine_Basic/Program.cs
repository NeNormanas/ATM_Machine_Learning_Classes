using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM_Machine_Basic.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Saskaita Normanas = new Saskaita() { manoKortele = new Kortele() { KortelesNumeris = "45632155", kortelesTipas = KortelesTipas.MasterCard, CVV = "523" }, SaskaitosLikutis = 1000, Vardas = "KAROLINA", Amzius = 25, SaskaitosNumeris = "LT00012556824", Pavarde = "Kolyte", };
            Saskaita Marta = new Saskaita() { manoKortele = new Kortele(), SaskaitosLikutis = 1250, Vardas = "ANDZEJ" };

            Normanas.pavedimai.Add(new Tranzakcijos() { MokejimoPaskirtis = "Skola", Suma = 25, Valiuta = Valiutos.EUR, Laikas = DateTime.Now });

            VartotojoVartas(Normanas, Marta);

            Console.ReadLine();
        }

        static void VartotojoVartas(Saskaita Normanas, Saskaita Marta)
        {
            Console.WriteLine("Iveskite savo vartotojo varda");
            string vartotojoVardas = Console.ReadLine().ToUpper();

            if (vartotojoVardas == Normanas.Vardas)
            {
                KalbosPasirinkimas(Normanas);

            }
            else if (vartotojoVardas == Marta.Vardas)
            {
                KalbosPasirinkimas(Marta);
            }
        }

        static void KalbosPasirinkimas(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Sveiki, pasirinkite kalba: \n 1.LT \n 2.EN \n 3.RU");
            int kalba = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (kalba)
            {
                case 1:
                    Console.WriteLine("Laba diena");
                    Console.ReadLine();
                    if (As.manoKortele.ArPINIvestasTeisingai)
                    {
                        Meniu(As);
                    }
                    else
                    {
                        PinIvedimas(As);
                    }
                    break;
                case 2:
                    Console.WriteLine("Hello");
                    Console.ReadLine();
                    if (As.manoKortele.ArPINIvestasTeisingai)
                    {
                        Meniu(As);
                    }
                    else
                    {
                        PinIvedimas(As);
                    }
                    break;
                case 3:
                    Console.WriteLine("Zdravstvujtje");
                    Console.ReadLine();
                    if (As.manoKortele.ArPINIvestasTeisingai)
                    {
                        Meniu(As);
                    }
                    else
                    {
                        PinIvedimas(As);
                    }
                    break;
                default:
                    Console.WriteLine("Pasirinkite kalba is naujo");
                    KalbosPasirinkimas(As);
                    break;
            }
        }

        static void PinIvedimas(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Iveskite pin koda");
            string ivedamasPin = "0";
            int bandymuSk = 0;
            int i = 0;
            while (i < 3 && !As.manoKortele.ArTeisingasPIN(ivedamasPin) && !As.manoKortele.ArPINIvestasTeisingai)

            {
                i++;
                ivedamasPin = Console.ReadLine();

                Console.Clear();
                if (As.manoKortele.ArTeisingasPIN(ivedamasPin))
                {
                    As.manoKortele.PirmasTeisingasPIN();
                    Meniu(As);
                }
                else
                {
                    bandymuSk++;
                    if (bandymuSk < 3)
                    {
                        Console.WriteLine("Pin kodas neteisingas, bandykte dar karta:");
                    }
                    else
                    {
                        Console.WriteLine("Pin kodas neteisingas, prisijungimas uzblokuotas.");
                    }

                }
            }
        }

        static void Meniu(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Meniu: \n1. Keisti kalba \n2. Keisti pin koda \n3. Saskaitos likutis \n4. Saskaitos israsas " +
                "\n5. Inesti pinigus \n6. Pasiimti pinigus \n7. Baigti darba");
            int meniuPasirinkimas = Convert.ToInt32(Console.ReadLine());
            switch (meniuPasirinkimas)
            {
                case 1:
                    KalbosPasirinkimas(As);
                    break;
                case 2:
                    KeistiPinKoda(As);
                    break;
                case 3:
                    SaskaitosLikuts(As);
                    break;
                case 4:
                    SaskaitosIsrasas(As);
                    break;
                case 5:
                    InestiPinigus(As);
                    break;
                case 6:
                    PasiimtiPinigus(As);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Atsijungete");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Pasirinkite is naujo");
                    Console.ReadLine();
                    Console.Clear();
                    Meniu(As);
                    break;
            }

        }

        static void KeistiPinKoda(Saskaita As)
        {
            Console.Clear();

            Console.WriteLine("Iveskite senaji pin koda:");
            string senasPin = Console.ReadLine();
            if (As.manoKortele.ArTeisingasPIN(senasPin))
            {
                NaujoPinIrasymas(As);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pin kodas neteisingas.");
                TestiArGriztiPin1(As);
            }
        }

        static void NaujoPinIrasymas(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Iveskite nauja pin koda");
            string naujasPin = Console.ReadLine();

            bool teisingasFormatas = int.TryParse(naujasPin, out int arGerasPinFormatas);

            if (teisingasFormatas && naujasPin.Length == 4)
            {
                As.manoKortele.ChangePIN(naujasPin);
                Console.WriteLine("Naujas pin kodas issaugotas.");
                Console.ReadLine();
                Meniu(As);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ivestas pin kodas neatitinka formato, iveskite keturis skaitmenis.");
                TestiArGriztiPin2(As);
            }
        }

        static void TestiArGriztiPin1(Saskaita As)
        {

            Console.WriteLine("1.Bandyti dar karta \n2.Grizti i meniu");
            int TestiArGrizti = Convert.ToInt32(Console.ReadLine());
            switch (TestiArGrizti)
            {
                case 1:
                    KeistiPinKoda(As);
                    break;
                case 2:
                    Meniu(As);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Tokio pasirinkimo nera, bandykite is naujo");
                    TestiArGriztiPin1(As);
                    break;
            }
        }

        static void TestiArGriztiPin2(Saskaita As)
        {
            Console.WriteLine("1.Bandyti dar karta \n2.Grizti i meniu");
            int TestiArGrizti = Convert.ToInt32(Console.ReadLine());
            switch (TestiArGrizti)
            {
                case 1:
                    NaujoPinIrasymas(As);
                    break;
                case 2:
                    Meniu(As);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Tokio pasirinkimo nera, bandykite is naujo");
                    TestiArGriztiPin2(As);
                    break;
            }
        }

        static void SaskaitosLikuts(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Jusu saskaitos likutis yra {0} eur", As.SaskaitosLikutis);
            Console.ReadLine();
            Meniu(As);
        }

        static void SaskaitosIsrasas(Saskaita As)
        {
            Console.Clear();

            As.Israsas();

            Console.ReadLine();
            Meniu(As);
        }

        static void InestiPinigus(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Iveskite valiuta, kuria norite isinesti pinigus (EUR, USD, GBP):");
            string ivestaValiuta = Console.ReadLine().ToUpper();
            Valiutos valiuta = Valiutos.EUR;
            switch (ivestaValiuta)
            {
                case "EUR":
                    valiuta = Valiutos.EUR;
                    break;
                case "USD":
                    valiuta = Valiutos.USD;
                    break;
                case "GBP":
                    valiuta = Valiutos.GBP;
                    break;
                default:
                    InestiPinigus(As);
                    break;
            }

            Console.WriteLine("Iveskite norima inesti suma:");
            double inesamaSuma = Convert.ToDouble(Console.ReadLine());

            Console.Clear();

            As.inestiPinigus(inesamaSuma, valiuta);
            As.pavedimai.Add(new Tranzakcijos() { MokejimoPaskirtis = "Grynuju pinigu inesimas", Suma = inesamaSuma, Valiuta = valiuta, Laikas = DateTime.Now });

            SaskaitosLikuts(As);
        }

        static void PasiimtiPinigus(Saskaita As)
        {
            Console.Clear();
            Console.WriteLine("Iveskite valiuta, kuria norite issiimti pinigus (EUR, USD, GBP):");
            string ivestaValiuta = Console.ReadLine().ToUpper();
            Valiutos valiuta = Valiutos.EUR;
            switch (ivestaValiuta)
            {
                case "EUR":
                    valiuta = Valiutos.EUR;
                    break;
                case "USD":
                    valiuta = Valiutos.USD;
                    break;
                case "GBP":
                    valiuta = Valiutos.GBP;
                    break;
                default:
                    PasiimtiPinigus(As);
                    break;
            }
            Console.WriteLine("Iveskite norima pasiimti suma:");
            double isimamaSuma = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            if (As.SaskaitosLikutis < isimamaSuma)
            {
                Console.WriteLine("Saskaitos likutis nepakankamas");
                Meniu(As);

            }
            else
            {
                As.issimtiPinigus(isimamaSuma, valiuta);
                As.pavedimai.Add(new Tranzakcijos() { MokejimoPaskirtis = "Grynuju pinigu isemimas", Suma = -isimamaSuma, Valiuta = valiuta, Laikas = DateTime.Now });

                SaskaitosLikuts(As);
            }
        }
    }
}
