namespace ConsoleApplication1.Uzytkownicy
{
    public class Student : UzytkownikSprzetu
    {
        public string NrIndeksu { get; set; }
        public int Semestr { get; set; }

        public Student(int idUzytkownika, string imie, string nazwisko, string nrIndeksu, int semestr) : base(idUzytkownika, imie, nazwisko)
        {
            NrIndeksu = nrIndeksu;
            Semestr = semestr;
        }
    }
}