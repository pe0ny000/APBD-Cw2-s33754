namespace ConsoleApplication1.DaneSprzetowe
{
    public class Sprzet
    {
        public int SprzetId { get; set; }
        public string SprzetNazwa { get; set; }
        public bool JestDostepny { get; set; }

        public Sprzet(int sprzetId, string sprzetNazwa,  bool jestDostepny = true)
        {
            SprzetId = sprzetId;
            SprzetNazwa = sprzetNazwa;
            JestDostepny = jestDostepny;
        }
    }
}