using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class EmailDirektoraMapiranja : ClassMap<EmailDirektora>
    {
        public EmailDirektoraMapiranja()
        {
            Table("EMAIL_DIREKTORA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Email, "EMAIL");

            References(x => x.Direktor).Column("ID_DIREKTORA").Not.Nullable().LazyLoad();
        }
    }
}
