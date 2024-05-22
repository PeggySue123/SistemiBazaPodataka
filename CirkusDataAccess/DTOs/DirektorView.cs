using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class DirektorView
    {
        public int Id { get; protected set; }
        public string Licno_Ime { get; set; }
        public string Srednje_Slovo { get; set; }
        public string Prezime { get; set; }
        public IList<EmailDirektoraView> Emailovi { get; set; }
        public IList<TelefonDirektoraView> Brojevi_Telefona { get; set; }

        public IList<ArtistaView> NadredjenArtistima { get; set; }
        public IList<ZivotinjaView> NabavljeneZivotinje { get; set; }
        public IList<PomocnoOsobljeView> Zaposljeno_Osoblje { get; set; }

        public DirektorView()
        {
            Emailovi = new List<EmailDirektoraView>();
            Brojevi_Telefona = new List<TelefonDirektoraView>();
            NadredjenArtistima = new List<ArtistaView>();
            NabavljeneZivotinje = new List<ZivotinjaView>();
            Zaposljeno_Osoblje = new List<PomocnoOsobljeView>();
        }

        public DirektorView(Direktor d)
        {
            Id = d.Id;
            Licno_Ime = d.Licno_Ime;
            Srednje_Slovo = d.Srednje_Slovo;
            Prezime = d.Prezime;
        }
    }
}
