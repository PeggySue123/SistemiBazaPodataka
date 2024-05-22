using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class ZonglerMapiranja : SubclassMap<Zongler>
    {
        public ZonglerMapiranja()
        {
            Table("ZONGLER");

            KeyColumn("ID");

            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.Broj_Predmeta).Column("BROJ_PREDMETA");
        }
    }
}
