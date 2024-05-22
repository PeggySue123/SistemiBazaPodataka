namespace CirkusDataAccess.Entiteti
{
    public class GradPredstava
    {
        public virtual int Id { get; protected set; }
        public virtual string Vreme_Odrzavanja { get; set; }
        public virtual int Broj_Prodatih_Karata { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Predstava Predstava { get; set; }
    }
}
