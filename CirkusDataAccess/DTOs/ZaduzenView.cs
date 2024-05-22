using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class ZaduzenView
    {
        public int Id { get; protected set; }

        public PomocnoOsobljeView Pomocno_Osoblje { get; set; }
        public CirkuskaTackaView Cirkuska_Tacka { get; set; }

        public ZaduzenView()
        {

        }

        public ZaduzenView(Zaduzen z)
        {
            Id = z.Id;
            Pomocno_Osoblje = new PomocnoOsobljeView(z.Pomocno_Osoblje);
            Cirkuska_Tacka = new CirkuskaTackaView(z.Cirkuska_Tacka);
        }
    }
}
