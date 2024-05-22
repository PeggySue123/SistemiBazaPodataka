using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class GutaciPlamenaView : ArtistaView
    {
        public IList<AsistentiView> Asistenti { get; set; }

        public GutaciPlamenaView() : base()
        {
            Asistenti = new List<AsistentiView>();
        }

        public GutaciPlamenaView(GutaciPlamena gp) : base(gp)
        {

        }
    }
}
