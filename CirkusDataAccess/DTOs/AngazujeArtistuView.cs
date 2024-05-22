using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class AngazujeArtistuView
    {
        public int Id { get; set; }

        public ArtistaView Artista { get; set; }
        public CirkuskaTackaView Cirkuska_Tacka { get; set; }

        public AngazujeArtistuView()
        {

        }

        public AngazujeArtistuView(AngazujeArtistu a)
        {
            Id = a.Id;
            Artista = new ArtistaView(a.Artista);
            Cirkuska_Tacka = new CirkuskaTackaView(a.Cirkuska_Tacka);
        }
    }
}
