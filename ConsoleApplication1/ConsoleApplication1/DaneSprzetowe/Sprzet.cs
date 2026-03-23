namespace ConsoleApplication1.DaneSprzetowe
{
    public class Sprzet
    {
        public int SprzetId { get; set; }
        public string SprzetNazwa { get; set; }

        public Sprzet(int sprzetId, string sprzetNazwa)
        {
            SprzetId = sprzetId;
            SprzetNazwa = sprzetNazwa;
        }
    }
}