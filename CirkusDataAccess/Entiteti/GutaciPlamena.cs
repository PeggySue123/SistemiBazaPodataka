using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class GutaciPlamena : Artista
    {
        public virtual IList<Asistenti> Asistenti { get; set; }

        public GutaciPlamena()
        {
            Asistenti = new List<Asistenti>();
        }
    }
}
