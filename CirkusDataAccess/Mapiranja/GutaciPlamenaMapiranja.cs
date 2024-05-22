using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class GutaciPlamenaMapiranja : SubclassMap<GutaciPlamena>
    {
        public GutaciPlamenaMapiranja()
        {
            Table("GUTACI_PLAMENA");

            KeyColumn("ID");

            HasMany(x => x.Asistenti).KeyColumn("ID_ARTISTE_SA_ASISTENTIMA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
