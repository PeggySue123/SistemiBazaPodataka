using CirkusDataAccess.Entiteti;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class PredstavaView
    {
        public int Id { get; protected set; }
        public int? Razlog_Organizovanja { get; set; }
        public float? Prihod { get; set; }
        public string Namenjen_Prihod { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public IList<TelefonNaruciocaView> Brojevi_Telefona_Narucioca { get; set; }

        public IList<GradView> Gradovi { get; set; }
        public IList<CirkuskaTackaView> Cirkuske_Tacke { get; set; }

        public PredstavaView()
        {
            Gradovi = new List<GradView>();
            Cirkuske_Tacke = new List<CirkuskaTackaView>();
            Brojevi_Telefona_Narucioca = new List<TelefonNaruciocaView>();
        }

        public PredstavaView(Predstava p)
        {
            Id = p.Id;
            Razlog_Organizovanja = p.Razlog_Organizovanja;
            Prihod = p.Prihod;
            Namenjen_Prihod = p.Namenjen_Prihod;
            Naziv = p.Naziv;
            Adresa = p.Adresa;
        }
    }

    public class RedovnaPredstavaView : PredstavaView
    {
        public RedovnaPredstavaView() : base()
        {

        }
        public RedovnaPredstavaView(RedovnaPredstava p)
        {
            Id = p.Id;
            Razlog_Organizovanja = null;
            Prihod = null;
            Namenjen_Prihod = null;
            Naziv = null;
            Adresa = null;
        }
    }

    public class HumanitarnaPredstavaView : PredstavaView
    {
        public HumanitarnaPredstavaView() : base()
        {

        }
        public HumanitarnaPredstavaView(HumanitarnaPredstava p)
        {
            Id = p.Id;
            Razlog_Organizovanja = 0;
            Prihod = p.Prihod;
            Namenjen_Prihod = p.Namenjen_Prihod;
            Naziv = null;
            Adresa = null;
        }
    }

    public class NarucenaPredstavaView : PredstavaView
    {
        public NarucenaPredstavaView() : base()
        {

        }
        public NarucenaPredstavaView(NarucenaPredstava p)
        {
            Id = p.Id;
            Razlog_Organizovanja = 1;
            Prihod = null;
            Namenjen_Prihod = null;
            Naziv = p.Naziv;
            Adresa = p.Adresa;
        }
    }
}
