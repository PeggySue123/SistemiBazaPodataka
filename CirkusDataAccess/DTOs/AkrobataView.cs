using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class AkrobataView : ArtistaView
    {
        public IList<VestinaView> Poseduje_Vestine { get; set; }

        public AkrobataView () : base ()
        {
            Poseduje_Vestine = new List<VestinaView>();
        }

        public AkrobataView (Akrobata a) : base(a)
        {

        }
    }
}
