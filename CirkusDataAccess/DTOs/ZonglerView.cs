using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class ZonglerView : ArtistaView
    {

        public string Naziv { get; set; }
        public int Broj_Predmeta { get; set; }

        public ZonglerView() : base()
        {

        }

        public ZonglerView(Zongler z) : base(z)
        {
            Naziv = z.Naziv;
            Broj_Predmeta = z.Broj_Predmeta;
        }
    }
}
