using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class CirkuskaTacka
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Opasni_Efekti { get; set; }
        public virtual int Donja_Granica_Uzrasta { get; set; }

        public virtual Predstava Pripada_Predstavi { get; set; }
        public virtual IList<PomocnoOsoblje> Pomocno_Osoblje { get; set; }
        public virtual IList<Artista> Artisti { get; set; }
        public virtual IList<Zivotinja> Zivotinje { get; set; }

        public CirkuskaTacka()
        {
            Pomocno_Osoblje = new List<PomocnoOsoblje>();
            Artisti = new List<Artista>();
            Zivotinje = new List<Zivotinja>();
        }
    }
}
