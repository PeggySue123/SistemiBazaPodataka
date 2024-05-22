using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class VestinaMapiranja : ClassMap<Vestina>
    {
        public VestinaMapiranja()
        {
            Table("VESTINA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Broj_Godina, "BROJ_GODINA");

            References(x => x.Akrobata).Column("ID_AKROBATE").LazyLoad();
        }
    }
}
