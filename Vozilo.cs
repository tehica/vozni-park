using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VozniPark
{
    class Vozilo
    {
        // dodao sam ovaj konstruktor da bi mogao kreirati zadana vozila u listi
        public Vozilo()
        {

        }

        public Vozilo(string markaVozila, string modelVozila)
        {
            MarkaVozila = markaVozila;
            ModelVozila = modelVozila;
        }

        public string MarkaVozila { get; set; }
        public string ModelVozila { get; set; }
        public string RegistarskaOznaka { get; set; }
        public DateTime DatumIzdavanjaRegistarskeOznake { get; set; }
        public DateTime DatumIstekaRegistracije { get; set; }

        // pozivanje Krivi unos.
        public void KriviUnos()
        {
            // https://www.dotnetperls.com/console-color
            // stranica na kojoj sam nasao kako se mijenja boja u konzoli
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Krivi unos.");
            Console.ResetColor();
        }

        public Vozilo KreirajNovoVozilo()
        {
            string markaVozila, modelVozila, registarskaOznaka;

            AzuriranjeVozila azuriranjeVozila = new AzuriranjeVozila();


            // Unos marke vozila
            markaVozila = azuriranjeVozila.KreiranjeMarkeVozila();

            // Unos modela vozila
            modelVozila = azuriranjeVozila.KreiranjeModelaVozila();

            // Unos registarske oznake vozila
            registarskaOznaka = azuriranjeVozila.KreiranjeRegistarskeOznake();

            // Kreiranje datuma izdavanja registarske oznake
            DateTime datumIzdavanjaRegistarskeOznake = azuriranjeVozila.KreiranjeDatumaIzdavanjaRegistarskeOznake();

            // Kreiranje datuma isteka registarske oznake
            DateTime datumIstekaRegistarskeOznake = DateTime.MaxValue;
            datumIstekaRegistarskeOznake = 
                    azuriranjeVozila.KreiranjeDatumaIstekaRegistarskeOznake(datumIzdavanjaRegistarskeOznake);


            Vozilo NovoVozilo = new Vozilo(markaVozila, modelVozila);
            NovoVozilo.RegistarskaOznaka = registarskaOznaka;
            NovoVozilo.DatumIzdavanjaRegistarskeOznake = datumIzdavanjaRegistarskeOznake;
            NovoVozilo.DatumIstekaRegistracije = datumIstekaRegistarskeOznake;
            return NovoVozilo;
        }

        public Vozilo AzuriranjePostojecegVozila(Vozilo voziloZaAzuriranje)
        {
            Console.WriteLine("\nTrenutni podaci vozila koje želite ažurirati:\n" +
                              "Marka vozila: {0}\n" +
                              "Model vozila: {1}\n" +
                              "Registarska oznaka: {2}\n" +
                              "Datum izdavanja registarske oznake: {3}\n" +
                              "Datum isteka registarske oznake: {4}\n",
                              voziloZaAzuriranje.MarkaVozila, voziloZaAzuriranje.ModelVozila,
                              voziloZaAzuriranje.RegistarskaOznaka,
                              voziloZaAzuriranje.DatumIzdavanjaRegistarskeOznake,
                              voziloZaAzuriranje.DatumIstekaRegistracije);

            int odabranaOpcijaIzbornika = 99;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Izbornik za ažuriranje odabranog vozila:\n" +
                                  "Ažuriranje marke vozila = 1\n" +
                                  "Ažuriranje modela vozila = 2\n" +
                                  "Ažuriranje registarske oznake = 3\n" +
                                  "Ažuriranje izdavanja registarske oznake = 4\n" +
                                  "Ažuriranje istake registarske oznake = 5\n" +
                                  "Prekid ažuriranja, izlaz iz izbornika = 0\n");
                Console.ResetColor();
                Console.Write("Odaberite jednu od opcija: ");

                try
                {
                    odabranaOpcijaIzbornika = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                if (odabranaOpcijaIzbornika == 0)
                {
                    Console.WriteLine("Kraj ažuriranja.");
                    break;
                }
                else if (odabranaOpcijaIzbornika > 0 && odabranaOpcijaIzbornika < 6)
                {
                    AzuriranjeVozila azuriranjeVozila = new AzuriranjeVozila();

                    switch (odabranaOpcijaIzbornika)
                    {
                        case 1:
                            voziloZaAzuriranje.MarkaVozila = azuriranjeVozila.KreiranjeMarkeVozila();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ažurirana marka vozila. :)");
                            Console.ResetColor();
                            break;
                        case 2:
                            voziloZaAzuriranje.ModelVozila = azuriranjeVozila.KreiranjeModelaVozila();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ažuriran model vozila. :)");
                            Console.ResetColor();
                            break;
                        case 3:
                            voziloZaAzuriranje.RegistarskaOznaka = azuriranjeVozila.KreiranjeRegistarskeOznake();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ažurirana registarska oznaka vozila. :)");
                            Console.ResetColor();
                            break;
                        case 4:
                            voziloZaAzuriranje.DatumIzdavanjaRegistarskeOznake =
                                azuriranjeVozila.KreiranjeDatumaIzdavanjaRegistarskeOznake(voziloZaAzuriranje.DatumIstekaRegistracije);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ažuriran datum izdavanja registarske oznake vozila. :)");
                            Console.ResetColor();
                            break;
                        case 5:
                            voziloZaAzuriranje.DatumIstekaRegistracije =
                                azuriranjeVozila.KreiranjeDatumaIstekaRegistarskeOznake(voziloZaAzuriranje.DatumIzdavanjaRegistarskeOznake);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ažuriran datum isteka registarske oznake vozila. :)");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Krivi unos.\n");
                }
                break;

            } while (true);


            return voziloZaAzuriranje;
        }

        public void IspisSvihVozila(List<Vozilo> vozila)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nIspis svih vozila:");
            Console.ResetColor();
            foreach (Vozilo v in vozila)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}. VOZILO:", vozila.IndexOf(v) +1);
                Console.ResetColor();
                Console.WriteLine("Id vozila: {0}\n" +
                                  "Marka vozila: {1}\n" +
                                  "Model vozila: {2}\n" +
                                  "Registarska oznaka: {3}\n" +
                                  "Datum izdavanja registarske oznake: {4}\n" +
                                  "Datum isteka registarske oznake: {5}\n", 
                                  vozila.IndexOf(v),
                                  v.MarkaVozila, v.ModelVozila,
                                  v.RegistarskaOznaka,
                                  v.DatumIzdavanjaRegistarskeOznake.ToShortDateString(),
                                  v.DatumIstekaRegistracije.ToShortDateString());
            }
        }


        public void VozilaSVazecomRegistracijom(List<Vozilo> vozila)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nIspis vozila s važećom registracijom:");
            Console.ResetColor();
            foreach (Vozilo v in vozila)
            {
                if(v.DatumIstekaRegistracije >= DateTime.Now.Date)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0}. VOZILO S VAŽEĆOM REGISTRACIJOM:", vozila.IndexOf(v) + 1);
                    Console.ResetColor();
                    Console.WriteLine("Id vozila: {0}\n" +
                                      "Marka vozila: {1}\n" +
                                      "Model vozila: {2}\n" +
                                      "Registarska oznaka: {3}\n" +
                                      "Datum izdavanja registarske oznake: {4}\n" +
                                      "Datum isteka registarske oznake: {5}\n",
                                      vozila.IndexOf(v),
                                      v.MarkaVozila, v.ModelVozila,
                                      v.RegistarskaOznaka,
                                      v.DatumIzdavanjaRegistarskeOznake.ToShortDateString(),
                                      v.DatumIstekaRegistracije.ToShortDateString());
                }
            }
        }

        public void IspisVozilaSIsteklomRegistracijom(List<Vozilo> vozila)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nIspis vozila s isteklom registracijom:");
            Console.ResetColor();
            foreach (Vozilo v in vozila)
            {
                if (v.DatumIstekaRegistracije < DateTime.Now.Date)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("{0}. VOZILO S ISTEKLOM REGISTRACIJOM:", vozila.IndexOf(v) + 1);
                    Console.ResetColor();
                    Console.WriteLine("Id vozila: {0}\n" +
                                      "Marka vozila: {1}\n" +
                                      "Model vozila: {2}\n" +
                                      "Registarska oznaka: {3}\n" +
                                      "Datum izdavanja registarske oznake: {4}\n" +
                                      "Datum isteka registarske oznake: {5}\n",
                                      vozila.IndexOf(v),
                                      v.MarkaVozila, v.ModelVozila,
                                      v.RegistarskaOznaka,
                                      v.DatumIzdavanjaRegistarskeOznake.ToShortDateString(),
                                      v.DatumIstekaRegistracije.ToShortDateString());
                }
            }
        }
    }
}
