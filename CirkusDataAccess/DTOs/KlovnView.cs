using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class KlovnView : ArtistaView
    {
        public int Tip { get; set; }
        public string Predmet_Za_Zabavu { get; set; }

        public KlovnView() : base()
        {

        }

        public KlovnView(Klovn k) : base(k)
        {
            Tip = k.Tip;
            Predmet_Za_Zabavu = k.Predmet_Za_Zabavu;
        }
    }
}
