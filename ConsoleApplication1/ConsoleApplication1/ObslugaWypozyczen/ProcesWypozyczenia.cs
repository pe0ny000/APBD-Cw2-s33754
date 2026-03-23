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


        public Wypozyczenie WypozyczSprzet(Sprzet sprzet, UzytkownikSprzetu uzytkownik, DateTime dataPlanowanegoZwrotu,
            double koszt)
        {
            if (!sprzet.JestDostepny)
                throw new Exception("Sprzęt nie jest dostępny");
            var wypozyczenie = new Wypozyczenie(
                _wypozyczenia.Count + 1, DateTime.Now, dataPlanowanegoZwrotu, koszt, sprzet, uzytkownik
            );

            sprzet.JestDostepny = false;

            _wypozyczenia.Add(wypozyczenie);
            return wypozyczenie;
        }

        public void ZwrocSprzet(int idWypozyczenia)
        {
            var wypozyczenie = _wypozyczenia.FirstOrDefault((w => w.IdWypozyczenie == idWypozyczenia));
            if (wypozyczenie == null) throw new Exception("Wypozyczenie nie istnieje");
            wypozyczenie?.ZwrotSprzetu();
            wypozyczenie.WypozyczonySprzet.JestDostepny = true;
        }
    }
}