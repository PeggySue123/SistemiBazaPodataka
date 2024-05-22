using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class KlovnMapiranja : SubclassMap<Klovn>
    {
        public KlovnMapiranja()
        {
            Table("KLOVN");

            KeyColumn("ID");

            Map(x => x.Tip).Column("TIP");
            Map(x => x.Predmet_Za_Zabavu).Column("PREDMET_ZA_ZABAVU");
        }
    }
}
