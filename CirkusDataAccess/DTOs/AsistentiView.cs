using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.DTOs
{
    public class AsistentiView : ArtistaView
    {
        public ArtistaView Artista_Sa_Asistentima { get; set; }

        public AsistentiView() : base()
        {

        }

        public AsistentiView(Asistenti a) : base(a)
        {
            Artista_Sa_Asistentima = new ArtistaView(a.Artista_Sa_Asistentima);
        }
    }
}
