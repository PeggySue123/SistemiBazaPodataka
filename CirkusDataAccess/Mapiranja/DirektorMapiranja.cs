using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class DirektorMapiranja : ClassMap<Direktor>
    {
        public DirektorMapiranja()
        {
            Table("DIREKTOR");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Licno_Ime, "LIME");
            Map(x => x.Srednje_Slovo, "SSLOVO");
            Map(x => x.Prezime, "PREZIME");

            HasMany(x => x.Emailovi).KeyColumn("ID_DIREKTORA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Brojevi_Telefona).KeyColumn("ID_DIREKTORA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.NadredjenArtistima).KeyColumn("ID_DIREKTORA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.NabavljeneZivotinje).KeyColumn("ID_DIREKTORA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Zaposljeno_Osoblje).KeyColumn("ID_DIREKTORA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
