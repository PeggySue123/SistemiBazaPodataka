namespace CirkusDataAccess.Entiteti
{
    public class AngazujeArtistu
    {
        public virtual int Id { get; protected set; }

        public virtual Artista Artista { get; set; }
        public virtual CirkuskaTacka Cirkuska_Tacka { get; set; }
    }
}
