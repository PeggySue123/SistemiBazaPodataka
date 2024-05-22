using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public abstract class Predstava
    {
        public virtual int Id { get; protected set; }
        public virtual int Tip_Predstave { get; set; }
        public virtual int? Razlog_Organizovanja { get; set; }
        public virtual float? Prihod { get; set; }
        public virtual string Namenjen_Prihod { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual IList<TelefonNarucioca> Brojevi_Telefona_Narucioca { get; set; }

        public virtual IList<Grad> Gradovi { get; set; }
        public virtual IList<CirkuskaTacka> Cirkuske_Tacke { get; set; }

        public Predstava()
        {
            Brojevi_Telefona_Narucioca = new List<TelefonNarucioca>();

            Gradovi = new List<Grad>();
            Cirkuske_Tacke = new List<CirkuskaTacka>();
        }
    }

    public class RedovnaPredstava : Predstava
    {

    }

    public class NarucenaPredstava : Predstava
    {

    }

    public class HumanitarnaPredstava : Predstava
    {

    }
}
