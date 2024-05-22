using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class AsistentiMapiranja : SubclassMap<Asistenti>
    {
        public AsistentiMapiranja()
        {
            Table("ASISTENTI");

            KeyColumn("ID");

            References(x => x.Artista_Sa_Asistentima).Column("ID_ARTISTE_SA_ASISTENTIMA").Not.Nullable();
        }
    }
}
