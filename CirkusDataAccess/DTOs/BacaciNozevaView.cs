using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class BacaciNozevaView : ArtistaView
    {
        public IList<AsistentiView> Asistenti { get; set; }

        public BacaciNozevaView() : base()
        {
            Asistenti = new List<AsistentiView>();
        }

        public BacaciNozevaView(BacaciNozeva b) : base(b)
        {

        }
    }
}
