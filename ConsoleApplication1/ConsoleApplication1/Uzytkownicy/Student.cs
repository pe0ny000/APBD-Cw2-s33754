namespace ConsoleApplication1.Uzytkownicy
{
    public class Student : UzytkownikSprzetu
    {
        public string NrIndeksu { get; set; }
        public int Semestr { get; set; }

        public Student(int idUzytkownika, string imie, string nazwisko, string nrIndeksu, int semestr,
            int iloscAktywnychWypozyczen) : base(idUzytkownika, imie, nazwisko, iloscAktywnychWypozyczen)
        {
            NrIndeksu = nrIndeksu;
            Semestr = semestr;
        }
    }
}