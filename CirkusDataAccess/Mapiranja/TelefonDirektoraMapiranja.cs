using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class TelefonDirektoraMapiranja : ClassMap<TelefonDirektora>
    {
        public TelefonDirektoraMapiranja()
        {
            Table("TELEFON_DIREKTORA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Broj_Telefona, "BROJ_TELEFONA");

            References(x => x.Direktor).Column("ID_DIREKTORA").LazyLoad();
        }
    }
}
