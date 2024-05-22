using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class TelefonDirektoraView
    {
        public int Id { get; protected set; }
        public string Broj_Telefona { get; set; }

        public DirektorView Direktor { get; set; }

        public TelefonDirektoraView()
        {

        }

        public TelefonDirektoraView(TelefonDirektora td)
        {
            Id = td.Id;
            Broj_Telefona = td.Broj_Telefona;
            Direktor = new DirektorView(td.Direktor);
        }
    }
}
