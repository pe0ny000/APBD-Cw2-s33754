using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.DaneSprzetowe;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1.ObslugaWypozyczen
{
    public class DzialaniaNaSprzecie
    {
        private List<Sprzet> _sprzety;

        public DzialaniaNaSprzecie(List<Sprzet> sprzety)
        {
            _sprzety = sprzety;
        }

        public void DodajSprzet()
        {
            Console.Write("Nazwa: ");
            string nazwa = Console.ReadLine();
            Console.Write("Koszt za dzień: ");
            double koszt = double.Parse(Console.ReadLine());
            Console.Write("Typ (1 - Laptop, 2 - Kamera, 3 - Projektor): ");
            string typ = Console.ReadLine();

            Sprzet sprzet = null;

            switch (typ)
            {
                case "1":
                    Console.Write("Procesor: ");
                    string procesor = Console.ReadLine();
                    Console.Write("Wielkosc ekranu (cale): ");
                    double wielkoscEkranu = double.Parse(Console.ReadLine());
                    sprzet = new Laptop(_sprzety.Count + 1, nazwa, true, true, koszt, procesor, wielkoscEkranu);
                    break;
                case "2":
                    Console.Write("Rozdzielczosc MPX: ");
                    double rozdzielczosc = double.Parse(Console.ReadLine());
                    Console.Write("Rodzaj matrycy: ");
                    string rodzajMatrycy = Console.ReadLine();
                    sprzet = new Camera(_sprzety.Count + 1, nazwa, true, true, koszt, rozdzielczosc, rodzajMatrycy);
                    break;
                case "3":
                    Console.Write("Jasnosc: ");
                    int jasnoc = int.Parse(Console.ReadLine());
                    Console.Write("Czy posiada Bluetooth: ");
                    bool posiadaBluetooth = bool.Parse(Console.ReadLine() ?? string.Empty);
                    sprzet = new Projektor(_sprzety.Count + 1, nazwa, true, true, koszt, jasnoc, posiadaBluetooth);
                    break;
                default:
                    Console.Write("Błędny typ sprzętu");
                    return;
            }

            _sprzety.Add(sprzet);
            Console.WriteLine("Dodano sprzęt.");
        }

        public void DodajLaptop(string nazwa, double koszt,
            string procesor, double wielkoscEkranu)
        {
            _sprzety.Add(new Laptop(_sprzety.Count + 1, nazwa, true,true, koszt, procesor, wielkoscEkranu));
            
        }

        public void DodajProjektor(string nazwa, double koszt,
            int jasnosc, bool posiadaBluetooth)
        {
            _sprzety.Add(new Projektor(_sprzety.Count + 1, nazwa, true,true, koszt, jasnosc,
                posiadaBluetooth));
           
        }

        public void DodajKamere(string nazwa, double koszt,
            double rodzielczoscMpx, string rodzajMatrycy)
        {
            _sprzety.Add(new Camera(_sprzety.Count + 1, nazwa, true, true, koszt, rodzielczoscMpx,
                rodzajMatrycy));
            
        }


        public void WyswietlCalySprzet()
        {
            foreach (var s in _sprzety)
                Console.WriteLine(
                    $"{s.SprzetId}. {s.SprzetNazwa} - {(s.JestDostepny ? "dostępny" : "niedostępny")} - {s.KosztWypozyczenia} zł/dzień");
        }

        public void WyswietlDostepnySprzet()
        {
            foreach (var s in _sprzety.Where(s => s.JestDostepny && s.NieJestUszkodzony))
                Console.WriteLine($"{s.SprzetId}. {s.SprzetNazwa} - {s.KosztWypozyczenia} zł/dzień");
        }

        public void OznaczNiedostepny()
        {
            WyswietlDostepnySprzet();
            Console.Write("ID sprzętu: ");
            int id = int.Parse(Console.ReadLine());
            var sprzet = _sprzety.First(s => s.SprzetId == id);
            sprzet.JestDostepny = false;
            Console.WriteLine("Oznaczono jako niedostępny.");
        }

        public Sprzet PobierzSprzet()
        {
            WyswietlDostepnySprzet();
            Console.Write("ID sprzętu: ");
            int id = int.Parse(Console.ReadLine());
            return _sprzety.First(s => s.SprzetId == id);
        }
        public Sprzet PobierzSprzet(int id) => _sprzety.First(s => s.SprzetId == id);
        
    }
}