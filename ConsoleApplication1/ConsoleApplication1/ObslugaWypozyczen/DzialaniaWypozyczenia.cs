using System;

namespace ConsoleApplication1.ObslugaWypozyczen
{
    public class DzialaniaWypozyczenia
    {
        private static ProcesWypozyczenia _proces;
        private static  DzialaniaNaSprzecie _sprzetUI;
        private static  DzialaniaNaUzytkownikach _uzytkownikUI;

        public DzialaniaWypozyczenia(ProcesWypozyczenia proces, DzialaniaNaSprzecie sprzetUI, DzialaniaNaUzytkownikach uzytkownikUI)
        {
            _proces = proces;
            _sprzetUI = sprzetUI;
            _uzytkownikUI = uzytkownikUI;
        }

        public static void WypozyczSprzet()
        {
            var sprzet = _sprzetUI.PobierzSprzet();
            var uzytkownik = _uzytkownikUI.PobierzUzytkownika();

            Console.Write("Data planowanego zwrotu (dd.MM.yyyy): ");
            DateTime dataZwrotu = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            try
            {
                var wypozyczenie = _proces.WypozyczSprzet(sprzet, uzytkownik, dataZwrotu);
                Console.WriteLine("Wypożyczono pomyślnie.");
                Console.WriteLine(wypozyczenie);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }

        public static void ZwrocSprzet()
        {
            Console.Write("ID wypożyczenia: ");
            int idWypozyczenia = int.Parse(Console.ReadLine());
            Console.Write("Czy jest uszkodzony: ");
            bool nieJestUszkodzony = bool.Parse(Console.ReadLine());
            _proces.ZwrocSprzet(idWypozyczenia, nieJestUszkodzony);
            Console.WriteLine("Zwrócono sprzęt.");
        }

        public static void AktywneWypozyczeniaUzytkownika()
        {
            var uzytkownik = _uzytkownikUI.PobierzUzytkownika();
            var aktywne = _proces.PobierzAktywneWypozyczeniaUzytkownika(uzytkownik.IdUzytkownika);
            foreach (var w in aktywne)
                Console.WriteLine(w);
        }

        public static void PrzeterminowaneWypozyczenia()
        {
            var przeterminowane = ProcesWypozyczenia.PobierzPrzeterminowaneWypozyczenia();
            foreach (var w in przeterminowane)
                Console.WriteLine(w);
        }
    }
}