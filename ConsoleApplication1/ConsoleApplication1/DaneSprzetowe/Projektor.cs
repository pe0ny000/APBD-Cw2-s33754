namespace ConsoleApplication1.DaneSprzetowe
{
    public class Projektor : Sprzet
    {
        public int Jasnosc{get;set;}
        public bool PosiadaBloototh{get;set;}

        public Projektor(int sprzetId, string sprzetNazwa, bool jestDostepny, double kosztWypozyczenia, int jasnosc, bool posiadaBloototh) : base(sprzetId, sprzetNazwa, jestDostepny, kosztWypozyczenia)
        {
            Jasnosc = jasnosc;
            PosiadaBloototh = posiadaBloototh;
        }
    }
}