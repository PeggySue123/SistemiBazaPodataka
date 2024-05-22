using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class PomocnoOsobljeMapiranja : ClassMap<PomocnoOsoblje>
    {
        public PomocnoOsobljeMapiranja()
        {
            Table("POMOCNO_OSOBLJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Maticni_Broj, "MATICNI_BROJ").Not.Nullable();
            Map(x => x.Licno_Ime, "LIME");
            Map(x => x.Srednje_Slovo, "SSLOVO");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.Mesto_Rodjenja, "MESTO_RODJENJA");
            Map(x => x.Datum_Rodjenja, "DATUM_RODJENJA");

            References(x => x.Direktor).Column("ID_DIREKTORA").Not.Nullable().LazyLoad();

            HasManyToMany(x => x.Cirkuske_Tacke)
                .Table("ZADUZEN")
                .ParentKeyColumn("ID_POMOCNOG_OSOBLJA")
                .ChildKeyColumn("ID_TACKE")
                .Cascade.All();
        }
    }
}
