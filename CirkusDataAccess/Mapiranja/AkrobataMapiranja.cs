using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class AkrobataMapiranja : SubclassMap<Akrobata>
    {
        public AkrobataMapiranja()
        {
            Table("AKROBATA");

            KeyColumn("ID");

            HasMany(x => x.Poseduje_Vestine).KeyColumn("ID_AKROBATE").LazyLoad().Cascade.All().Inverse();
        }
    }
}
