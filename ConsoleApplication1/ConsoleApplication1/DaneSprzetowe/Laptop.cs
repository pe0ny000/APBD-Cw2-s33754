namespace ConsoleApplication1.DaneSprzetowe
{
    public class Laptop : Sprzet
    {
        public string Procesor { get; set; }
        public double WielkoscEkranu { get; set; }

        public Laptop(int sprzetId, string sprzetNazwa, bool jestDostepny, bool nieJestUszkodzony, double kosztWypozyczenia, string procesor, double wielkoscEkranu) : base(sprzetId, sprzetNazwa, kosztWypozyczenia, jestDostepny, nieJestUszkodzony)
        {
            Procesor = procesor;
            WielkoscEkranu = wielkoscEkranu;
        }
    }
}