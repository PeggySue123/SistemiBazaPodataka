using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class TelefonNaruciocaMapiranja : ClassMap<TelefonNarucioca>
    {
        public TelefonNaruciocaMapiranja()
        {
            Table("TELEFON_NARUCIOCA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Broj_Telefona, "BROJ_TELEFONA");

            References(x => x.Narucioc_Predstave).Column("ID_PREDSTAVE").LazyLoad();
        }
    }
}
