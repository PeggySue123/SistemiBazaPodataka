using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class AngazujeArtistuMapiranja : ClassMap<AngazujeArtistu>
    {
        public AngazujeArtistuMapiranja()
        {
            Table("ANGAZUJE_ARTISTU");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Artista).Column("ID_ARTISTE");
            References(x => x.Cirkuska_Tacka).Column("ID_TACKE");
        }
    }
}
