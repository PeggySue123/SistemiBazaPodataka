using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class GradPredstavaView
    {

        public int Id { get; protected set; }
        public string Vreme_Odrzavanja { get; set; }
        public int Broj_Prodatih_Karata { get; set; }

        public GradView Grad { get; set; }
        public PredstavaView Predstava { get; set; }

        public GradPredstavaView()
        {

        }

        public GradPredstavaView(GradPredstava gp)
        {
            Id = gp.Id;
            Vreme_Odrzavanja = gp.Vreme_Odrzavanja;
            Broj_Prodatih_Karata = gp.Broj_Prodatih_Karata;

            Grad = new GradView(gp.Grad);
            Predstava = new PredstavaView(gp.Predstava);
        }
    }
}
