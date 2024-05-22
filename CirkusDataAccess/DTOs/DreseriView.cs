using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class DreseriView : ArtistaView
    {
        public IList<ZivotinjaView> Dresira { get; set; }
        public IList<AsistentiView> Asistenti { get; set; }

        public DreseriView() : base()
        {
            Dresira = new List<ZivotinjaView>();
            Asistenti = new List<AsistentiView>();
        }

        public DreseriView(Dreseri d) : base(d)
        {

        }
    }
}
