using CirkusDataAccess.Entiteti;
using System;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class ArtistaView
    {
        public int Id { get; protected set; }
        public string Maticni_Broj { get; set; }
        public DateTime Datum_Rodjenja { get; set; }
        public string Nadimak { get; set; }
        public string Licno_Ime { get; set; }
        public string Ime_Roditelja { get; set; }
        public string Prezime { get; set; }
        public DateTime Pocetak_Rada { get; set; }
        public char Pol { get; set; }
        public string Mesto_Rodjenja { get; set; }

        public DirektorView Direktor { get; set; }
        public IList<CirkuskaTackaView> Cirkuske_Tacke { get; set; }

        public ArtistaView()
        {
            Cirkuske_Tacke = new List<CirkuskaTackaView>();
        }
        public ArtistaView(Artista a)
        {
            Id = a.Id;
            Maticni_Broj = a.Maticni_Broj;
            Datum_Rodjenja = a.Datum_Rodjenja;
            Nadimak = a.Nadimak;
            Licno_Ime = a.Licno_Ime;
            Ime_Roditelja = a.Ime_Roditelja;
            Prezime = a.Prezime;
            Pocetak_Rada = a.Pocetak_Rada;
            Pol = a.Pol;
            Mesto_Rodjenja = a.Mesto_Rodjenja;
            Direktor = new DirektorView(a.Direktor);
        }
    }
}
