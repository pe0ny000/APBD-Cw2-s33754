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
        private List<Wypozyczenie> _wypozyczenia = new List<Wypozyczenie>();


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

        public void ZwrocSprzet(int idWypozyczenia, UzytkownikSprzetu uzytkownik, bool nieJestUszkodzony)
        {
            var wypozyczenie = _wypozyczenia.FirstOrDefault((w => w.IdWypozyczenie == idWypozyczenia));
            if (wypozyczenie == null) throw new Exception("Wypozyczenie nie istnieje");
            wypozyczenie?.ZwrotSprzetu();
            
            wypozyczenie.WypozyczonySprzet.NieJestUszkodzony = nieJestUszkodzony;
            wypozyczenie.WypozyczonySprzet.JestDostepny = true;
            uzytkownik.IloscAktywnychWypozyczen -= 1;
        }
        
        public List<Wypozyczenie> AktywneWypozyczeniaUzytkownika(int idUzytkownika)
        {
            return _wypozyczenia.Where(w => w.Uzytkownik.IdUzytkownika == idUzytkownika && w.DataFaktycznegoZwrotu == default)
                .ToList();
        }


        public List<Wypozyczenie> PrzeterminowaneWypozyczenia()
        {
            return
                _wypozyczenia.Where(w => w.DataFaktycznegoZwrotu == default && w.DataPlanowanegoZwrotu < DateTime.Now)
                    .ToList();
        }

        public void WyswietlRaport()
        {
            int aktywne = _wypozyczenia.Count(w => w.DataFaktycznegoZwrotu == default);
            int zakonczone = _wypozyczenia.Count(w => w.DataFaktycznegoZwrotu != default);
            int przeterminowane = PrzeterminowaneWypozyczenia().Count;
            Console.WriteLine($"Aktywne wypożyczenia: {aktywne}");
            Console.WriteLine($"Zakończone wypożyczenia: {zakonczone}");
            Console.WriteLine($"Przeterminowane: {przeterminowane}");
        }
    }
}