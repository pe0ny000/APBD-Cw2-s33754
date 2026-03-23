namespace ConsoleApplication1.DaneSprzetowe
{
    public class Laptop : Sprzet
    {
        public string Procesor { get; set; }
        public double WielkoscEkranu { get; set; }

        public Laptop(int sprzetId, string sprzetNazwa, string procesor, double wielkoscEkranu, bool jestDostepny) :
            base(sprzetId, sprzetNazwa, jestDostepny)
        {
            Procesor = procesor;
            WielkoscEkranu = wielkoscEkranu;
        }
    }
}