using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class VestinaView
    {
        public int Id { get; protected set; }
        public string Naziv { get; set; }
        public float Broj_Godina { get; set; }

        public AkrobataView Akrobata { get; set; }

        public VestinaView()
        {

        }

        public VestinaView(Vestina v)
        {
            Id = v.Id;
            Naziv = v.Naziv;
            Broj_Godina = v.Broj_Godina;
            Akrobata = new AkrobataView(v.Akrobata);
        }
    }
}
