using System;
using System.Collections.Generic;
using ConsoleApplication1.DaneSprzetowe;
using ConsoleApplication1.ObslugaWypozyczen;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var uzytkownicy = new List<UzytkownikSprzetu>();
            var sprzety = new List<Sprzet>();
            var proces = new ProcesWypozyczenia();

            var dzialaniaNaUzytkownikach = new DzialaniaNaUzytkownikach(uzytkownicy);
            var dzialaniaNaSprzecie = new DzialaniaNaSprzecie(sprzety);
            var dzialaniaWypozyczenia =
                new DzialaniaWypozyczenia(proces, dzialaniaNaSprzecie, dzialaniaNaUzytkownikach);

            dzialaniaNaSprzecie.DodajLaptop("Dell XPS 15",  50.0, "Intel i7", 15.6);
            dzialaniaNaSprzecie.DodajLaptop("MacBook Pro",  80.0, "Apple M3", 14.0);

            dzialaniaNaSprzecie.DodajProjektor("Epson EB-X51", 30.0, 3800, false);
            dzialaniaNaSprzecie.DodajProjektor("BenQ MH560",  35.0, 4000, true);

            dzialaniaNaSprzecie.DodajKamere("Sony ZV-E10",  60.0, 24.2, "APS-C");
            dzialaniaNaSprzecie.DodajKamere("Canon EOS R50",  70.0, 24.2, "CMOS");
            
            dzialaniaNaUzytkownikach.DodajPracownika("Anna", "Kowalska", "nauczyciel", 5000);
            dzialaniaNaUzytkownikach.DodajPracownika("Piotr", "Nowak", "ochroniarz", 3500);
            dzialaniaNaUzytkownikach.DodajPracownika("Maria", "Wiśniewska", "nauczyciel", 4800);

            dzialaniaNaUzytkownikach.DodajStudenta("Marek", "Kowalski", "s12345", 3);
            dzialaniaNaUzytkownikach.DodajStudenta("Julia", "Nowak", "s23456", 1);
            dzialaniaNaUzytkownikach.DodajStudenta("Tomasz", "Wiśniewski", "s34567", 5);
            
            bool dziala = true;
            while (dziala)
            {
                Console.WriteLine("\n=== SYSTEM WYPOŻYCZALNI ===");
                Console.WriteLine("1. Dodaj nowego użytkownika");
                Console.WriteLine("2. Dodaj nowy sprzęt");
                Console.WriteLine("3. Lista całego sprzętu");
                Console.WriteLine("4. Lista dostępnego sprzętu");
                Console.WriteLine("5. Wypożycz sprzęt");
                Console.WriteLine("6. Zwróć sprzęt");
                Console.WriteLine("7. Wypisz aktywne wypożyczenia użytkownika");
                Console.WriteLine("8. Wypisz przeterminowane wypożyczenia");
                Console.WriteLine("9. Napisz raport");
                Console.WriteLine("0. Wyjście");
                Console.Write("\nWybierz opcję: ");

                switch (Console.ReadLine())
                {
                    case "1": dzialaniaNaUzytkownikach.DodajUzytkownika(); break;
                    case "2": dzialaniaNaSprzecie.DodajSprzet(); break;
                    case "3": dzialaniaNaSprzecie.WyswietlCalySprzet(); break;
                    case "4": dzialaniaNaSprzecie.WyswietlDostepnySprzet(); break;
                    case "5": dzialaniaWypozyczenia.WypozyczSprzet(); break;
                    case "6": dzialaniaWypozyczenia.ZwrocSprzet(); break;
                    case "7": dzialaniaWypozyczenia.AktywneWypozyczeniaUzytkownika(); break;
                    case "8": dzialaniaWypozyczenia.PrzeterminowaneWypozyczenia(); break;
                    case "9": proces.WyswietlRaport(); break;
                    case "0": dziala = false; break;
                    default: Console.WriteLine("Nieprawidłowa opcja."); break;
                }
            }
        }
    }
}