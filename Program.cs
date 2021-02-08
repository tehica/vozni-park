using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Zadatak: Evidencija voznog parka
/*
Opis zadatka: 
Kreirajte klasu imena "Vozilo" koja sadrži pet svojstava (varijabli):

Marka vozila
Model vozila
Registarska oznaka (registracija)
Datum izdavanja registarske oznake
Datum isteka registracije
Kreirajte konstruktor koji prima dva parametara (marka i model vozila).

Kreirajte get i set metode za sve parametre.

Kreirajte C# program koji sadrži izbornik sa sljedećim opcijama:
Dodavanje novog vozila
Ažuriranje postojećeg vozila
Ispis svih vozila
Ispis vozila sa važećom registacijom
Ispis vozila sa isteklom registracijom
Prekid rada programa
Podaci svih vozila moraju biti pohranjeni u listi, tj. svako novo vozilo (objekt) mora biti dodano u listu vozila.

Opcija ažuriranja podataka postojećeg vozila mora omogućiti izmjenu podataka vozila iz liste.

Nakon odabira određene opcije i izvođenja potrebnih operacija vezanih za odabranu opciju, program mora ponovo ponuditi izbornik i omogućiti korisniku novi izbor.

Program se mora izvoditi sve dok na izborniku nije odabrana opcija prekida rada programa.
*/
#endregion

namespace VozniPark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vozilo> vozila = new List<Vozilo>()
            {
                new Vozilo
                {
                   MarkaVozila = "Mercedes",
                   ModelVozila = "GLE",
                   RegistarskaOznaka = "HR8801ZT",
                   DatumIzdavanjaRegistarskeOznake = new DateTime(2020, 02, 02),
                   DatumIstekaRegistracije = new DateTime(2021, 02, 02)
                },
                new Vozilo
                {
                   MarkaVozila = "BMW",
                   ModelVozila = "M4",
                   RegistarskaOznaka = "HR7712UZ",
                   DatumIzdavanjaRegistarskeOznake = new DateTime(2020, 03, 03),
                   DatumIstekaRegistracije = new DateTime(2021, 03, 03)
                },
                new Vozilo
                {
                   MarkaVozila = "AUDI",
                   ModelVozila = "A7",
                   RegistarskaOznaka = "HR1234OL",
                   DatumIzdavanjaRegistarskeOznake = new DateTime(2020, 04, 04),
                   DatumIstekaRegistracije = new DateTime(2021, 04, 04)
                },
                new Vozilo
                {
                    MarkaVozila = "BMW",
                    ModelVozila = "X7",
                    RegistarskaOznaka = "HR4522HJ",
                    DatumIzdavanjaRegistarskeOznake = new DateTime(2018, 06, 20),
                    DatumIstekaRegistracije = new DateTime(2019, 06, 20)
                }
            };

            int odabranaOpcijaIzbornika = 99;
            Vozilo vozilo = new Vozilo(string.Empty, string.Empty);

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nIzbornik:\n" +
                                  "Dodavanje novog vozila = 1\n" +
                                  "Ažuriranje postojećeg vozila = 2\n" +
                                  "Ispis svih vozila = 3\n" +
                                  "Ispis vozila sa važećom registacijom = 4\n" +
                                  "Ispis vozila sa isteklom registracijom = 5\n" +
                                  "Prekid rada programa = 0\n");
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
                

                if(odabranaOpcijaIzbornika == 0) {
                    Console.WriteLine("Kraj programa.");
                    break;
                }
                else if (odabranaOpcijaIzbornika > 0 && odabranaOpcijaIzbornika < 6)
                {
                    switch (odabranaOpcijaIzbornika)
                    {
                        case 1:
                            vozila.Add(vozilo.KreirajNovoVozilo());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Uspješno ste dodali novo vozilo.\n\n");
                            Console.ResetColor();
                            break;
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.Write("Unesite Id vozila koje želite ažurirati: ");
                                    int idVozila = int.MinValue;
                                    idVozila = int.Parse(Console.ReadLine());
                                    if (idVozila > -1 && idVozila < vozila.Count)
                                    {
                                        //Console.WriteLine(idVozila); Console.WriteLine("Dobar unos.");
                                        var azuriranoVozilo = vozilo.AzuriranjePostojecegVozila(vozila[idVozila]);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Id ne postoji.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if(ex.GetType() == typeof(FormatException))
                                    {
                                        Console.WriteLine("Krivi format unosa.");
                                    }
                                }
                                
                            } while (true);
                            break;
                        case 3:
                            vozilo.IspisSvihVozila(vozila);
                            break;
                        case 4:
                            vozilo.VozilaSVazecomRegistracijom(vozila);
                            break;
                        case 5:
                            vozilo.IspisVozilaSIsteklomRegistracijom(vozila);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Krivi unos.\n");
                }
            }
            while (true);

            Console.ReadKey();
        }
    }
}
