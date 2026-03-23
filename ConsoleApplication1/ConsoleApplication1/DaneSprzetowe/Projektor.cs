namespace ConsoleApplication1.DaneSprzetowe
{
    public class Projektor : Sprzet
    {
        public int Jasnosc{get;set;}
        public bool PosiadaBloototh{get;set;}

        public Projektor(int sprzetId, string sprzetNazwa, int jasnosc, bool posiadaBloototh, bool jestDostepny) : base(sprzetId, sprzetNazwa, jestDostepny)
        {
            Jasnosc = jasnosc;
            PosiadaBloototh = posiadaBloototh;
        }
    }
}