using System;
using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class Zivotinja
    {
        public virtual int Id { get; protected set; }
        public virtual string Nadimak { get; set; }
        public virtual string Vrsta { get; set; }
        public virtual char Pol { get; set; }
        public virtual float Starost { get; set; }
        public virtual float Vreme_Boravka { get; set; }
        public virtual DateTime Datum_Veterinarskog_Pregleda { get; set; }
        public virtual int Broj_Kaveza { get; set; }
        public virtual float Tezina { get; set; }

        public virtual Dreseri Dreser { get; set; }
        public virtual Direktor Direktor { get; set; }

        public virtual IList<CirkuskaTacka> Cirkuske_Tacke { get; set; }

        public Zivotinja()
        {
            Cirkuske_Tacke = new List<CirkuskaTacka>();
        }
    }
}
