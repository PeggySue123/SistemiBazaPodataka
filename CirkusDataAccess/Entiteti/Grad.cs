using System;
using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class Grad
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv_Drzave { get; set; }
        public virtual string Naziv_Grada { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }
        public virtual string Opis { get; set; }

        public virtual IList<Predstava> Predstave { get; set; }

        public Grad()
        {
            Predstave = new List<Predstava>();
        }
    }
}
