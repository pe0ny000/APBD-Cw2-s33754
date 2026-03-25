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
        public Sprzet WypozyczonySprzet { get; set; }
        public UzytkownikSprzetu Uzytkownik{get; set;}
        public double KosztWypozyczenia => ObliczKoszt();

        public Wypozyczenie(int idWypozyczenie, DateTime dataWypozyczenia, DateTime dataPlanowanegoZwrotu, Sprzet wypozyczonySprzet, UzytkownikSprzetu uzytkownik)
        {
            IdWypozyczenie = idWypozyczenie;
            DataWypozyczenia = dataWypozyczenia;
            DataPlanowanegoZwrotu = dataPlanowanegoZwrotu;
            
            WypozyczonySprzet = wypozyczonySprzet;
            Uzytkownik = uzytkownik;
        }

        public void ZwrotSprzetu()
        {
            DataFaktycznegoZwrotu = DateTime.Now;
        }
        public double ObliczKoszt()
        {
            DateTime dataZwrotu = DataFaktycznegoZwrotu == default ? DateTime.Now : DataFaktycznegoZwrotu;
            int dni = (int)(dataZwrotu - DataWypozyczenia).TotalDays;
            double koszt = dni * WypozyczonySprzet.KosztWypozyczenia;

            if (DataFaktycznegoZwrotu > DataPlanowanegoZwrotu)
            {
                int dniOpoznienia = (int)(DataFaktycznegoZwrotu - DataPlanowanegoZwrotu).TotalDays;
                double kara = dniOpoznienia * WypozyczonySprzet.KosztWypozyczenia * 1.5; //wysokość kary za opóźnienie w zwrocie
                koszt += kara;
            }

            return koszt;
        }

        public override string ToString()
        {
            return $" {WypozyczonySprzet} wypożyczony przez {Uzytkownik}, koszt {KosztWypozyczenia} zł. ";
        }
    }
}