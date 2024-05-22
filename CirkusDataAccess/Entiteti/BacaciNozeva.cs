using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class BacaciNozeva : Artista
    {
        public virtual IList<Asistenti> Asistenti { get; set; }

        public BacaciNozeva()
        {
            Asistenti = new List<Asistenti>();
        }
    }
}
