using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class Dreseri : Artista
    {
        public virtual IList<Zivotinja> Dresira { get; set; }
        public virtual IList<Asistenti> Asistenti { get; set; }

        public Dreseri()
        {
            Dresira = new List<Zivotinja>();
            Asistenti = new List<Asistenti>();
        }
    }
}
