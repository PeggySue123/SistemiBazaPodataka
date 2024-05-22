using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class BacaciNozevaMapiranja : SubclassMap<BacaciNozeva>
    {
        public BacaciNozevaMapiranja()
        {
            Table("BACACI_NOZEVA");

            KeyColumn("ID");

            HasMany(x => x.Asistenti).KeyColumn("ID_ARTISTE_SA_ASISTENTIMA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
