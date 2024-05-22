using CirkusDataAccess.Entiteti;
using System;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class ZivotinjaView
    {
        public int Id { get; protected set; }
        public string Nadimak { get; set; }
        public string Vrsta { get; set; }
        public char Pol { get; set; }
        public float Starost { get; set; }
        public float Vreme_Boravka { get; set; }
        public DateTime Datum_Veterinarskog_Pregleda { get; set; }
        public int Broj_Kaveza { get; set; }
        public float Tezina { get; set; }

        public DreseriView Dreser { get; set; }
        public DirektorView Direktor { get; set; }

        public virtual IList<CirkuskaTackaView> Cirkuske_Tacke { get; set; }

        public ZivotinjaView()
        {
            Cirkuske_Tacke = new List<CirkuskaTackaView>();
        }

        public ZivotinjaView(Zivotinja z)
        {
            Id = z.Id;
            Nadimak = z.Nadimak;
            Vrsta = z.Vrsta;
            Pol = z.Pol;
            Starost = z.Starost;
            Vreme_Boravka = z.Vreme_Boravka;
            Datum_Veterinarskog_Pregleda = z.Datum_Veterinarskog_Pregleda;
            Broj_Kaveza = z.Broj_Kaveza;
            Tezina = z.Tezina;
            Dreser = new DreseriView(z.Dreser);
            Direktor = new DirektorView(z.Direktor);
        }
    }
}
