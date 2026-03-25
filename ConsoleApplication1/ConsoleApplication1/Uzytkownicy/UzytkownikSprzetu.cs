namespace ConsoleApplication1.Uzytkownicy
{
    public class UzytkownikSprzetu
    {
        public int IdUzytkownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IloscAktywnychWypozyczen{get; set;}
        public virtual int MaksymalnaIloscWypozyczen => 5;

        public UzytkownikSprzetu(int idUzytkownika, string imie, string nazwisko, int iloscAktywnychWypozyczen)
        {
            IdUzytkownika = idUzytkownika;
            Imie = imie;
            Nazwisko = nazwisko;
            IloscAktywnychWypozyczen = iloscAktywnychWypozyczen;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}