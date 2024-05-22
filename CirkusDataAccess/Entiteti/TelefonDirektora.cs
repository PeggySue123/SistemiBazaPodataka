namespace CirkusDataAccess.Entiteti
{
    public class TelefonDirektora
    {
        public virtual int Id { get; protected set; }
        public virtual string Broj_Telefona { get; set; }

        public virtual Direktor Direktor { get; set; }
    }
}
