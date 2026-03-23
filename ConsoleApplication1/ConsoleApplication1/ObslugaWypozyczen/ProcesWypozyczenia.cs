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
            
            
            var wypozyczenie = new Wypozyczenie(
                _wypozyczenia.Count + 1, DateTime.Now, dataPlanowanegoZwrotu,sprzet, uzytkownik
            );

            sprzet.JestDostepny = false;
            uzytkownik.IloscAktywnychWypozyczen += 1;

            _wypozyczenia.Add(wypozyczenie);
            return wypozyczenie;
        }

        public void ZwrocSprzet(int idWypozyczenia, UzytkownikSprzetu uzytkownik)
        {
            var wypozyczenie = _wypozyczenia.FirstOrDefault((w => w.IdWypozyczenie == idWypozyczenia));
            if (wypozyczenie == null) throw new Exception("Wypozyczenie nie istnieje");
            wypozyczenie?.ZwrotSprzetu();
            wypozyczenie.WypozyczonySprzet.JestDostepny = true;
            uzytkownik.IloscAktywnychWypozyczen -= 1;
        }

       
    }
}