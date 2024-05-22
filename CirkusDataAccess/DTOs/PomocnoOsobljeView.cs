using CirkusDataAccess.Entiteti;
using System;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class PomocnoOsobljeView
    {
        public int Id { get; protected set; }
        public string Maticni_Broj { get; set; }
        public string Licno_Ime { get; set; }
        public string Srednje_Slovo { get; set; }
        public string Prezime { get; set; }
        public char Pol { get; set; }
        public string Mesto_Rodjenja { get; set; }
        public DateTime Datum_Rodjenja { get; set; }

        public DirektorView Direktor { get; set; }

        public virtual IList<CirkuskaTackaView> Cirkuske_Tacke { get; set; }

        public PomocnoOsobljeView()
        {
            Cirkuske_Tacke = new List<CirkuskaTackaView>();
        }

        public PomocnoOsobljeView(PomocnoOsoblje po)
        {
            Id = po.Id;
            Maticni_Broj = po.Maticni_Broj;
            Licno_Ime = po.Licno_Ime;
            Srednje_Slovo = po.Srednje_Slovo;
            Prezime = po.Prezime;
            Pol = po.Pol;
            Mesto_Rodjenja = po.Mesto_Rodjenja;
            Datum_Rodjenja = po.Datum_Rodjenja;
            Direktor = new DirektorView(po.Direktor);
        }
    }
}
