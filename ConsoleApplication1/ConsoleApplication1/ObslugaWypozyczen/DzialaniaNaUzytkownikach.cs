using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1.ObslugaWypozyczen
{
    public class DzialaniaNaUzytkownikach
    {
        private  List<UzytkownikSprzetu> _uzytkownicy;

        public DzialaniaNaUzytkownikach(List<UzytkownikSprzetu> uzytkownicy)
        {
            _uzytkownicy = uzytkownicy;
        }

        public void DodajUzytkownika()
        {
            Console.Write("Imię: ");
            string imie = Console.ReadLine();
            Console.Write("Nazwisko: ");
            string nazwisko = Console.ReadLine();
            Console.Write("Typ (1 - Pracownik, 2 - Student): ");
            string typ = Console.ReadLine();

            UzytkownikSprzetu uzytkownik = null;
            switch (typ)
            {
                case "1":
                    Console.Write("Rodzaj pracownika (nauczyciel, ochroniarz, inny pracownik): ");
                    string rodzajPracownika = Console.ReadLine();
                    Console.Write("Wysokość wypłaty ");
                    double wysokoscWyplaty = Convert.ToDouble(Console.ReadLine());
                    uzytkownik = new Pracownik(_uzytkownicy.Count + 1, imie, nazwisko, rodzajPracownika, wysokoscWyplaty, 0);
                    break;
                case "2":
                    Console.Write("Numer indeksu: ");
                    string numerIndeksu = Console.ReadLine();
                    Console.Write("Semestr: ");
                    int semestr = Convert.ToInt32(Console.ReadLine());
                    uzytkownik = new Student(_uzytkownicy.Count + 1, imie, nazwisko, numerIndeksu, semestr, 0);
                    break;
                default:
                    Console.Write("Nieprawidłowy typ użytkownika");
                    return;
            }

            _uzytkownicy.Add(uzytkownik);
            Console.WriteLine("Dodano użytkownika.");
        }
        
        public void DodajPracownika(string imie, string nazwisko, string rodzajPracownika, double wysokoscWyplaty)
        {
            _uzytkownicy.Add(new Pracownik(_uzytkownicy.Count + 1, imie, nazwisko, rodzajPracownika, wysokoscWyplaty, 0));
        }

        public void DodajStudenta(string imie, string nazwisko, string numerIndeksu, int semestr)
        {
            _uzytkownicy.Add(new Student(_uzytkownicy.Count + 1, imie, nazwisko, numerIndeksu, semestr, 0));
        }

        public void WyswietlUzytkownikow()
        {
            foreach (var uzytkownik in _uzytkownicy)
            {
                Console.WriteLine($"{uzytkownik.Imie}, {uzytkownik.Nazwisko}, {uzytkownik.IdUzytkownika}");
            }
        }

        public UzytkownikSprzetu PobierzUzytkownika()
        {
            WyswietlUzytkownikow();
            Console.Write("Id uzytkownika: ");
            int idUzytkownika = int.Parse(Console.ReadLine());
            return _uzytkownicy.First(u =>u.IdUzytkownika == idUzytkownika);
        }
        
    }
}