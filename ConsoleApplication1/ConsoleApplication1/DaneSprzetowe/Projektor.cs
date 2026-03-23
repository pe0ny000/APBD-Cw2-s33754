namespace ConsoleApplication1.DaneSprzetowe
{
    public class Projektor : Sprzet
    {
        public int Jasnosc{get;set;}
        public bool PosiadaBloototh{get;set;}

        public Projektor(int sprzetId, string sprzetNazwa, int jasnosc, bool posiadaBloototh) : base(sprzetId, sprzetNazwa)
        {
            Jasnosc = jasnosc;
            PosiadaBloototh = posiadaBloototh;
        }
    }
}