using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class GradMapiranja : ClassMap<Grad>
    {
        public GradMapiranja()
        {
            Table("GRAD");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv_Drzave, "NAZIV_DRZAVE");
            Map(x => x.Naziv_Grada, "NAZIV_GRADA");
            Map(x => x.Datum_Od, "DATUM_OD");
            Map(x => x.Datum_Do, "DATUM_DO");
            Map(x => x.Opis, "OPIS");

            HasManyToMany(x => x.Predstave)
                .Table("GRAD_PREDSTAVA")
                .ParentKeyColumn("ID_GRADA")
                .ChildKeyColumn("ID_PREDSTAVE")
                .Inverse()
                .Cascade.All();
        }
    }
}
