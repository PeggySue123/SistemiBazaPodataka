using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class AngazujeZivotinjuMapiranja : ClassMap<AngazujeZivotinju>
    {
        public AngazujeZivotinjuMapiranja()
        {
            Table("ANGAZUJE_ZIVOTINJU");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Zivotinja).Column("ID_ZIVOTINJE");
            References(x => x.Cirkuska_Tacka).Column("ID_TACKE");
        }
    }
}
