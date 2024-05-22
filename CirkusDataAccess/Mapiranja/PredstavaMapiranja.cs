using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class PredstavaMapiranja : ClassMap<Predstava>
    {
        public PredstavaMapiranja()
        {
            Table("PREDSTAVA");

            DiscriminateSubClassesOnColumn("TIP_PREDSTAVE").Not.Nullable();

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Razlog_Organizovanja, "RAZLOG_ORGANIZOVANJA");
            Map(x => x.Prihod, "PRIHOD");
            Map(x => x.Namenjen_Prihod, "NAMENJEN_PRIHOD");
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Adresa, "ADRESA");

            HasMany(x => x.Brojevi_Telefona_Narucioca).KeyColumn("ID_PREDSTAVE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Cirkuske_Tacke).KeyColumn("ID_PREDSTAVE").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Gradovi)
                .Table("GRAD_PREDSTAVA")
                .ParentKeyColumn("ID_PREDSTAVE")
                .ChildKeyColumn("ID_GRADA")
                .Cascade.All();
        }
    }

    class RedovnaPredstavaMapiranja : SubclassMap<RedovnaPredstava>
    {
        public RedovnaPredstavaMapiranja()
        {
            DiscriminatorValue(0);
        }
    }
    class HumanitarnaPredstavaMapiranja : SubclassMap<HumanitarnaPredstava>
    {
        public HumanitarnaPredstavaMapiranja()
        {
            DiscriminatorValue(1);
        }
    }

    class NarucenaPredstavaMapiranja : SubclassMap<NarucenaPredstava>
    {
        public NarucenaPredstavaMapiranja()
        {
            DiscriminatorValue(1);
        }
    }
}
