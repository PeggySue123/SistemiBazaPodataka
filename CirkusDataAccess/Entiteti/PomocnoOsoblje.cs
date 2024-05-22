using System;
using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class PomocnoOsoblje
    {
        public virtual int Id { get; protected set; }
        public virtual string Maticni_Broj { get; set; }
        public virtual string Licno_Ime { get; set; }
        public virtual string Srednje_Slovo { get; set; }
        public virtual string Prezime { get; set; }
        public virtual char Pol { get; set; }
        public virtual string Mesto_Rodjenja { get; set; }
        public virtual DateTime Datum_Rodjenja { get; set; }

        public virtual Direktor Direktor { get; set; }

        public virtual IList<CirkuskaTacka> Cirkuske_Tacke { get; set; }

        public PomocnoOsoblje()
        {
            Cirkuske_Tacke = new List<CirkuskaTacka>();
        }
    }
}
