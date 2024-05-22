using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class Direktor
    {
        public virtual int Id { get; protected set; }
        public virtual string Licno_Ime { get; set; }
        public virtual string Srednje_Slovo { get; set; }
        public virtual string Prezime { get; set; }
        public virtual IList<EmailDirektora> Emailovi { get; set; }
        public virtual IList<TelefonDirektora> Brojevi_Telefona { get; set; }

        public virtual IList<Artista> NadredjenArtistima { get; set; }
        public virtual IList<Zivotinja> NabavljeneZivotinje { get; set; }
        public virtual IList<PomocnoOsoblje> Zaposljeno_Osoblje { get; set; }

        public Direktor()
        {
            Emailovi = new List<EmailDirektora>();
            Brojevi_Telefona = new List<TelefonDirektora>();

            NadredjenArtistima = new List<Artista>();
            NabavljeneZivotinje = new List<Zivotinja>();
            Zaposljeno_Osoblje = new List<PomocnoOsoblje>();
        }
    }
}
