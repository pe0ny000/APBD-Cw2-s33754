namespace ConsoleApplication1.Uzytkownicy
{
    public class Pracownik : UzytkownikSprzetu
    {
        public string RodzajPracownika { get; set; }
        public double Wyplata { get; set; }
        public override int MaksymalnaIloscWypozyczen => 5;
        public Pracownik(int idUzytkownika, string imie, string nazwisko, string rodzajPracownika, double wyplata,
            int iloscAktywnychWypozyczen) : base(idUzytkownika, imie, nazwisko,  iloscAktywnychWypozyczen)
        {
            RodzajPracownika = rodzajPracownika;
            Wyplata = wyplata;
        }
    }
}