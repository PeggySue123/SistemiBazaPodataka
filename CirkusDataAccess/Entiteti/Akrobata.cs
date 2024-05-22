using System.Collections.Generic;

namespace CirkusDataAccess.Entiteti
{
    public class Akrobata : Artista
    {
        public virtual IList<Vestina> Poseduje_Vestine { get; set; }

        public Akrobata()
        {
            Poseduje_Vestine = new List<Vestina>();
        }
    }
}
