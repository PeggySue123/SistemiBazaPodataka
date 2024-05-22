using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class ArtistaMapiranja : ClassMap<Artista>
    {
        public ArtistaMapiranja()
        {
            Table("ARTISTA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Maticni_Broj, "MATICNI_BROJ").Not.Nullable();
            Map(x => x.Datum_Rodjenja, "DATUM_RODJENJA");
            Map(x => x.Nadimak, "NADIMAK");
            Map(x => x.Licno_Ime, "LIME");
            Map(x => x.Ime_Roditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pocetak_Rada, "POCETAK_RADA");
            Map(x => x.Pol, "POL");
            Map(x => x.Mesto_Rodjenja, "MESTO_RODJENJA");

            References(x => x.Direktor).Column("ID_DIREKTORA").Not.Nullable().LazyLoad();

            HasManyToMany(x => x.Cirkuske_Tacke)
                .Table("ANGAZUJE_ARTISTU")
                .ParentKeyColumn("ID_ARTISTE")
                .ChildKeyColumn("ID_TACKE")
                .Inverse()
                .Cascade.All();
        }
    }
}
