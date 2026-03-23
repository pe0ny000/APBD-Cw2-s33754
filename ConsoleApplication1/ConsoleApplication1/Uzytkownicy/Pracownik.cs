namespace ConsoleApplication1.Uzytkownicy
{
    public class Pracownik : UzytkownikSprzetu
    {
        public string RodzajPracownika { get; set; }
        public double Wyplata { get; set; }

        public Pracownik(int idUzytkownika, string imie, string nazwisko, string rodzajPracownika, double wyplata) : base(idUzytkownika, imie, nazwisko)
        {
            RodzajPracownika = rodzajPracownika;
            Wyplata = wyplata;
        }
    }
}