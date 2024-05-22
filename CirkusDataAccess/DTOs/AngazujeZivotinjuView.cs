using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class AngazujeZivotinjuView
    {
        public int Id { get; protected set; }

        public ZivotinjaView Zivotinja { get; set; }
        public CirkuskaTackaView Cirkuska_Tacka { get; set; }

        public AngazujeZivotinjuView()
        {

        }

        public AngazujeZivotinjuView(AngazujeZivotinju z)
        {
            Id = z.Id;
            Zivotinja = new ZivotinjaView(z.Zivotinja);
            Cirkuska_Tacka = new CirkuskaTackaView(z.Cirkuska_Tacka);
        }
    }
}
