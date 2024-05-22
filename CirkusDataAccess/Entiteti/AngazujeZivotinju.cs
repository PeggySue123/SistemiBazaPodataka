namespace CirkusDataAccess.Entiteti
{
    public class AngazujeZivotinju
    {
        public virtual int Id { get; protected set; }

        public virtual Zivotinja Zivotinja { get; set; }
        public virtual CirkuskaTacka Cirkuska_Tacka { get; set; }
    }
}
