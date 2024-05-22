using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class TelefonNaruciocaView
    {
        public int Id { get; protected set; }
        public string Broj_Telefona { get; set; }

        public PredstavaView Narucioc_Predstave { get; set; }

        public TelefonNaruciocaView()
        {

        }

        public TelefonNaruciocaView(TelefonNarucioca tn)
        {
            Id = tn.Id;
            Broj_Telefona = tn.Broj_Telefona;
            Narucioc_Predstave = new PredstavaView(tn.Narucioc_Predstave);
        }
    }
}
