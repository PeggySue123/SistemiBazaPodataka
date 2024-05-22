using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class ZaduzenMapiranja : ClassMap<Zaduzen>
    {
        public ZaduzenMapiranja()
        {
            Table("ZADUZEN");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Pomocno_Osoblje).Column("ID_POMOCNOG_OSOBLJA").LazyLoad();
            References(x => x.Cirkuska_Tacka).Column("ID_TACKE").LazyLoad();
        }
    }
}
