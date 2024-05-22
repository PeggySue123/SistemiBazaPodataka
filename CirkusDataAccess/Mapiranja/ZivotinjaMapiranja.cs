using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class ZivotinjaMapiranja : ClassMap<Zivotinja>
    {
        public ZivotinjaMapiranja()
        {
            Table("ZIVOTINJA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Nadimak, "NADIMAK");
            Map(x => x.Vrsta, "VRSTA");
            Map(x => x.Pol, "POL");
            Map(x => x.Starost, "STAROST");
            Map(x => x.Vreme_Boravka, "VREME_BORAVKA");
            Map(x => x.Datum_Veterinarskog_Pregleda, "DATUM_VETERINARSKOG_PREGLEDA");
            Map(x => x.Broj_Kaveza, "BROJ_KAVEZA");
            Map(x => x.Tezina, "TEZINA");

            References(x => x.Dreser).Column("ID_DRESERA").LazyLoad();
            References(x => x.Direktor).Column("ID_DIREKTORA").LazyLoad();

            HasManyToMany(x => x.Cirkuske_Tacke)
                .Table("ANGAZUJE_ZIVOTINJE")
                .ParentKeyColumn("ID_ZIVOTINJE")
                .ChildKeyColumn("ID_TACKE")
                .Cascade.All();
        }
    }
}
