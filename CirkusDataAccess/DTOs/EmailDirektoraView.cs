using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class EmailDirektoraView
    {
        public int Id { get; protected set; }
        public string Email { get; set; }

        public DirektorView Direktor { get; set; }

        public EmailDirektoraView()
        {

        }

        public EmailDirektoraView(EmailDirektora ed)
        {
            Id = ed.Id;
            Email = ed.Email;
            Direktor = new DirektorView(ed.Direktor);
        }
    }
}
