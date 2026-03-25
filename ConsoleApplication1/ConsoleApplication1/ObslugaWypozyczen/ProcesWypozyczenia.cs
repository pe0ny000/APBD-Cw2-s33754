using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.DaneSprzetowe;
using ConsoleApplication1.DaneWypożyczenia;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1.ObslugaWypozyczen
{
    public class ProcesWypozyczenia
    {
        private static List<Wypozyczenie> _wypozyczenia = new List<Wypozyczenie>();


        public Wypozyczenie WypozyczSprzet(Sprzet sprzet, UzytkownikSprzetu uzytkownik, DateTime dataPlanowanegoZwrotu)
        {
            if (!sprzet.JestDostepny)
                throw new Exception("Sprzęt nie jest dostępny");
            if (uzytkownik.IloscAktywnychWypozyczen >= uzytkownik.MaksymalnaIloscWypozyczen)
                throw new Exception($"{uzytkownik.Imie} {uzytkownik.Nazwisko} osiągnął limit wypożyczeń");
            if(!sprzet.NieJestUszkodzony)
                throw new Exception("Sprzet jest uszkodzony");
            
            var wypozyczenie = new Wypozyczenie(
                _wypozyczenia.Count + 1, DateTime.Now, dataPlanowanegoZwrotu,sprzet, uzytkownik
            );

            sprzet.JestDostepny = false;
            uzytkownik.IloscAktywnychWypozyczen += 1;

            _wypozyczenia.Add(wypozyczenie);
            return wypozyczenie;
        }

        public void ZwrocSprzet(int idWypozyczenia, bool nieJestUszkodzony)
        {
            var wypozyczenie = _wypozyczenia.FirstOrDefault(w => w.IdWypozyczenie == idWypozyczenia);
            if (wypozyczenie == null) throw new Exception("Wypożyczenie nie istnieje.");
    
            wypozyczenie.ZwrotSprzetu();
            wypozyczenie.WypozyczonySprzet.NieJestUszkodzony = nieJestUszkodzony;
            wypozyczenie.WypozyczonySprzet.JestDostepny = nieJestUszkodzony; // niedostępny jeśli uszkodzony
            wypozyczenie.Uzytkownik.IloscAktywnychWypozyczen -= 1;
        }
        
        public List<Wypozyczenie> PobierzAktywneWypozyczeniaUzytkownika(int idUzytkownika)
        {
            return _wypozyczenia.Where(w => w.Uzytkownik.IdUzytkownika == idUzytkownika && w.DataFaktycznegoZwrotu == default)
                .ToList();
        }


        public static List<Wypozyczenie> PobierzPrzeterminowaneWypozyczenia()
        {
            return
                _wypozyczenia.Where(w => w.DataFaktycznegoZwrotu == default && w.DataPlanowanegoZwrotu < DateTime.Now)
                    .ToList();
        }

        public void WyswietlRaport()
        {
            int aktywne = _wypozyczenia.Count(w => w.DataFaktycznegoZwrotu == default);
            int zakonczone = _wypozyczenia.Count(w => w.DataFaktycznegoZwrotu != default);
            int przeterminowane = PobierzPrzeterminowaneWypozyczenia().Count;
            Console.WriteLine($"Aktywne wypożyczenia: {aktywne}");
            Console.WriteLine($"Zakończone wypożyczenia: {zakonczone}");
            Console.WriteLine($"Przeterminowane: {przeterminowane}");
        }
    }
}