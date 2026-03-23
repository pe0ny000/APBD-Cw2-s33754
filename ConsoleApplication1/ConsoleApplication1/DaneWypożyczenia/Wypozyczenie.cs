using System;
using System.Data;
using ConsoleApplication1.DaneSprzetowe;
using ConsoleApplication1.Uzytkownicy;

namespace ConsoleApplication1.DaneWypożyczenia
{
    public class Wypozyczenie
    {
        
        public int IdWypozyczenie { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataPlanowanegoZwrotu { get; set; }
        public DateTime DataFaktycznegoZwrotu { get; set; }
        public double KosztWypozyczenia { get; set; }
        public Sprzet WypozyczonySprzet { get; set; }
        public UzytkownikSprzetu Uzytkownik{get; set;}

        public Wypozyczenie(int idWypozyczenie, DateTime dataWypozyczenia, DateTime dataPlanowanegoZwrotu, double kosztWypozyczenia, Sprzet wypozyczonySprzet, UzytkownikSprzetu uzytkownik)
        {
            this.IdWypozyczenie = idWypozyczenie;
            DataWypozyczenia = dataWypozyczenia;
            DataPlanowanegoZwrotu = dataPlanowanegoZwrotu;
            KosztWypozyczenia = kosztWypozyczenia;
            WypozyczonySprzet = wypozyczonySprzet;
            Uzytkownik = uzytkownik;
        }

        public void ZwrotSprzetu()
        {
            DataFaktycznegoZwrotu = DateTime.Now;
        }
    }
}