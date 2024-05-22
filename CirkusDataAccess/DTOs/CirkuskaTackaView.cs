using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class CirkuskaTackaView
    {
        public int Id { get; protected set; }
        public string Ime { get; set; }
        public string Tip { get; set; }
        public string Opasni_Efekti { get; set; }
        public int Donja_Granica_Uzrasta { get; set; }

        public PredstavaView Pripada_Predstavi { get; set; }
        public IList<PomocnoOsobljeView> Pomocno_Osoblje { get; set; }
        public IList<ArtistaView> Artisti { get; set; }
        public IList<ZivotinjaView> Zivotinje { get; set; }

        public CirkuskaTackaView()
        {
            Pomocno_Osoblje = new List<PomocnoOsobljeView>();
            Artisti = new List<ArtistaView>();
            Zivotinje = new List<ZivotinjaView>();
        }

        public CirkuskaTackaView(CirkuskaTacka ct)
        {
            Id = ct.Id;
            Ime = ct.Ime;
            Tip = ct.Tip;
            Opasni_Efekti = ct.Opasni_Efekti;
            Donja_Granica_Uzrasta = ct.Donja_Granica_Uzrasta;
            Pripada_Predstavi = new PredstavaView(ct.Pripada_Predstavi);
        }
    }
}
