namespace CirkusDataAccess.Entiteti
{
    public class Klovn : Artista
    {
        public virtual int Tip { get; set; }
        public virtual string Predmet_Za_Zabavu { get; set; }
    }
}
