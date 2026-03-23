namespace ConsoleApplication1.DaneSprzetowe
{
    public class Camera : Sprzet
    {
        public double RozdzielczoscMPX { get; set; }
        public string RodzajMatrycy { get; set; }

        public Camera(int sprzetId, string sprzetNazwa, double rozdzielczoscMpx, string rodzajMatrycy) : base(sprzetId, sprzetNazwa)
        {
            RozdzielczoscMPX = rozdzielczoscMpx;
            RodzajMatrycy = rodzajMatrycy;
        }
    }
}