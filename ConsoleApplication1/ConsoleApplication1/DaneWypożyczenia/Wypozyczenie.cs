using System;

namespace ConsoleApplication1.DaneWypożyczenia
{
    public class Wypozyczenie
    {
        public string DataWypozyczenia { get; set; }
        public string DataPlanowanegoZwrotu { get; set; }
        public string DataFaktycznegoZwrotu { get; set; }
        public double KosztWypozyczenia { get; set; }

        public Wypozyczenie(string dataWypozyczenia, string dataPlanowanegoZwrotu, string dataFaktycznegoZwrotu, double kosztWypozyczenia)
        {
            DataWypozyczenia = dataWypozyczenia;
            DataPlanowanegoZwrotu = dataPlanowanegoZwrotu;
            DataFaktycznegoZwrotu = dataFaktycznegoZwrotu;
            KosztWypozyczenia = kosztWypozyczenia;
        }

        public void ZwrotSprzetu()
        {
            DataFaktycznegoZwrotu = DateTime.Now;
        }
    }
}