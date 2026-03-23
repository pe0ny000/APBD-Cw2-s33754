namespace ConsoleApplication1.DaneSprzetowe
{
    public class Laptop : Sprzet
    {
        public string Procesor { get; set; }
        public double WielkoscEkranu { get; set; }

        public Laptop(int sprzetId, string sprzetNazwa, bool jestDostepny, double kosztWypozyczenia, string procesor, double wielkoscEkranu) : base(sprzetId, sprzetNazwa, jestDostepny, kosztWypozyczenia)
        {
            Procesor = procesor;
            WielkoscEkranu = wielkoscEkranu;
        }
    }
}