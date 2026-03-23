namespace ConsoleApplication1.DaneSprzetowe
{
    public class Projektor : Sprzet
    {
        public int Jasnosc{get;set;}
        public bool PosiadaBluetooth{get;set;}

        public Projektor(int sprzetId, string sprzetNazwa, bool jestDostepny, bool nieJestUszkodzony, double kosztWypozyczenia, int jasnosc, bool posiadaBluetooth) : base(sprzetId, sprzetNazwa, kosztWypozyczenia, jestDostepny, nieJestUszkodzony)
        {
            Jasnosc = jasnosc;
            PosiadaBluetooth = posiadaBluetooth;
        }
    }
}