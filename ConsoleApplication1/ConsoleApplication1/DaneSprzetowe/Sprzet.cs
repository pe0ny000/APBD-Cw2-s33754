namespace ConsoleApplication1.DaneSprzetowe
{
    public class Sprzet
    {
        public int SprzetId { get; set; }
        public string SprzetNazwa { get; set; }
        public bool JestDostepny { get; set; }
        public bool NieJestUszkodzony { get; set; }
        public double KosztWypozyczenia { get; set; }

        public Sprzet(int sprzetId, string sprzetNazwa, double kosztWypozyczenia,
            bool jestDostepny = true, bool nieJestUszkodzony = true)
        {
            SprzetId = sprzetId;
            SprzetNazwa = sprzetNazwa;
            JestDostepny = jestDostepny;
            NieJestUszkodzony = nieJestUszkodzony;
            KosztWypozyczenia = kosztWypozyczenia;
        }
    }
}