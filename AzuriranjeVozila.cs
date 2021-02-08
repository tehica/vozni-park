using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VozniPark
{
    class AzuriranjeVozila
    {
        // Kreiranje marke vozila
        public string KreiranjeMarkeVozila()
        {
            string markaVozila;
            do
            {
                Console.Write("\nUnesite novi naziv marke vozila: ");
                markaVozila = Console.ReadLine();

                /*
                    https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426
                    Našao sam na ovoj poveznici kako provjeriti u stringu jesu li svi znakovi:
                    - slova
                    - slova i brojevi
                */
                if (markaVozila.Length < 3 || !Regex.IsMatch(markaVozila, @"^[a-zA-Z]+$"))
                {
                    // https://www.dotnetperls.com/console-color
                    // stranica na kojoj sam nasao kako se mijenja boja u konzoli
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Krivi unos.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            } while (true);

            return markaVozila;
        }

        // Kreiranje modela vozila
        public string KreiranjeModelaVozila()
        {
            string modelVozila;
            do
            {
                Console.Write("Unesite model vozila: ");
                modelVozila = Console.ReadLine();
                if (Regex.IsMatch(modelVozila, @"^[a-zA-Z0-9]+$"))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Krivi unos.");
                    Console.ResetColor();
                }
            } while (true);

            return modelVozila;
        }

        // Kreiranje registarske oznake
        public string KreiranjeRegistarskeOznake()
        {
            string registarskaOznaka;
            string prvaDvaSlovaRegistracije, brojcanaVrijednostTegistracije, zadnjaDvaSlovaRegistracije;
            Console.WriteLine("Registarska oznaka.\n");
            do
            {
                Console.WriteLine("Unesite prva dva slova registraske oznake. (npr. ZG, ST, ZD, ...)");
                Console.Write("Unos: ");
                prvaDvaSlovaRegistracije = Console.ReadLine();
                if(prvaDvaSlovaRegistracije.Length == 2 && Regex.IsMatch(prvaDvaSlovaRegistracije, @"^[a-žA-Ž]+$"))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Krivi unos.");
                    Console.ResetColor();
                }
            } while (true);
            do
            {
                Console.Write("Unesite 3-4 znamenke + zadnja dva slova registraske oznake.(npr. 456DF ili 4567DF)\n" +
                              "Unesite registarsku oznaku vozila: ");
                registarskaOznaka = Console.ReadLine();

                if (registarskaOznaka.Length == 5)
                {
                    brojcanaVrijednostTegistracije = registarskaOznaka.Substring(0, 3);
                    //Console.WriteLine(brojcanaVrijednostTegistracije);
                    if (Regex.IsMatch(brojcanaVrijednostTegistracije, @"^\d+$"))
                    {
                        zadnjaDvaSlovaRegistracije = registarskaOznaka.Substring(3, 2);
                        //Console.WriteLine(zadnjaDvaSlovaRegistracije);
                        if (Regex.IsMatch(zadnjaDvaSlovaRegistracije, @"^[a-zA-Z]+$"))
                        {
                            //Console.WriteLine("Svi svu upisani brojevi.\nDobar unos.");
                            registarskaOznaka = prvaDvaSlovaRegistracije + registarskaOznaka.ToUpper();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Krivi unos.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Krivi unos.");
                    }
                }
                else if (registarskaOznaka.Length == 6)
                {
                    brojcanaVrijednostTegistracije = registarskaOznaka.Substring(0, 4);
                    if (Regex.IsMatch(brojcanaVrijednostTegistracije, @"^\d+$"))
                    {
                        zadnjaDvaSlovaRegistracije = registarskaOznaka.Substring(4, 2);
                        if (Regex.IsMatch(zadnjaDvaSlovaRegistracije, @"^[a-zA-Z]+$"))
                        {
                            //Console.WriteLine("Svi svu upisani brojevi.\nDobar unos.");
                            registarskaOznaka = prvaDvaSlovaRegistracije + registarskaOznaka.ToUpper();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Krivi unos.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Krivi unos.");
                    }
                }
                else
                {
                    Console.WriteLine("Krivi unos.");
                }
            } while (true);

            return registarskaOznaka;
        }


        // Kreiranje datuma izdavanja registarske oznake
        public DateTime KreiranjeDatumaIzdavanjaRegistarskeOznake(DateTime? istekPostojeceRegistarskeOznake = null)
        {
            DateTime datumIzdavanjaRegistarskeOznake = DateTime.MinValue;

            if (istekPostojeceRegistarskeOznake == null)
            {
                do
                {
                    Console.Write("Unesite datum izdavanja registarske oznake: ");
                    bool provjeraDatumaIzdavanja = DateTime.TryParse(Console.ReadLine(), out datumIzdavanjaRegistarskeOznake);
                    // 12/12/2020
                    //Console.WriteLine(datumIzdavanjaRegistarskeOznake);
                    if (provjeraDatumaIzdavanja == true && datumIzdavanjaRegistarskeOznake >= DateTime.Now.Date)
                    {
                        break;
                    }
                    else if(datumIzdavanjaRegistarskeOznake < DateTime.Now.Date)
                    {
                        Console.WriteLine("Datum izdavanja registarske oznake ne može biti manji od današnjeg datuma.");
                    }
                    else
                    {
                        Console.WriteLine("Krivi format datuma.");
                    }
                } while (true);

            }
            else
            {
                do
                {
                    Console.Write("Unesite novi datum izdavanja registarske oznake: ");
                    bool provjeraDatumaIzdavanja = DateTime.TryParse(Console.ReadLine(), out datumIzdavanjaRegistarskeOznake);
                    if (provjeraDatumaIzdavanja == true && datumIzdavanjaRegistarskeOznake < istekPostojeceRegistarskeOznake)
                    {
                        break;
                    }
                    else if(datumIzdavanjaRegistarskeOznake > istekPostojeceRegistarskeOznake)
                    {
                        Console.WriteLine("Datum izdavanja registarske oznake ne može biti veći od datuma isteka.");
                    }
                    else
                    {
                        Console.WriteLine("Krivi unos.");
                    }
                } while (true);
            }
            return datumIzdavanjaRegistarskeOznake;
        }


        // Kreiranje datuma isteka registarske oznake
        public DateTime KreiranjeDatumaIstekaRegistarskeOznake(DateTime datumIzdavanjaRegistarskeOznake)
        {
            DateTime datumIstekaRegistarskeOznake = DateTime.MaxValue;
            do
            {
                Console.Write("Unesite datum isteka registarske oznake: ");
                bool provjeraDatumaIsteka = DateTime.TryParse(Console.ReadLine(), out datumIstekaRegistarskeOznake);

                if (provjeraDatumaIsteka == true && datumIstekaRegistarskeOznake > datumIzdavanjaRegistarskeOznake)
                {
                    break;
                }
                else if (datumIstekaRegistarskeOznake <= datumIzdavanjaRegistarskeOznake)
                {
                    Console.WriteLine("Datum isteka registarske oznake mora biti veći od datuma izdavanja.");
                }
                else
                {
                    Console.WriteLine("Krivi format datuma.");
                }

            } while (true);

            return datumIstekaRegistarskeOznake;
        }

    }
}
