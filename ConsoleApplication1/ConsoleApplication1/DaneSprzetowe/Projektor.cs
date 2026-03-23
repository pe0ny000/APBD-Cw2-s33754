namespace ConsoleApplication1.DaneSprzetowe
{
    public class Projektor : Sprzet
    {
        public int Jasnosc{get;set;}
        public bool PosiadaBloototh{get;set;}

        public Projektor(int sprzetId, string sprzetNazwa, bool jestDostepny, bool nieJestUszkodzony, double kosztWypozyczenia, int jasnosc, bool posiadaBloototh) : base(sprzetId, sprzetNazwa, kosztWypozyczenia, jestDostepny, nieJestUszkodzony)
        {
            Jasnosc = jasnosc;
            PosiadaBloototh = posiadaBloototh;
        }
    }
}