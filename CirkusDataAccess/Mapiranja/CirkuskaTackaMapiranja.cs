using FluentNHibernate.Mapping;
using CirkusDataAccess.Entiteti;

namespace CirkusDataAccess.Mapiranja
{
    internal class CirkuskaTackaMapiranja : ClassMap<CirkuskaTacka>
    {
        public CirkuskaTackaMapiranja()
        {
            Table("CIRKUSKA_TACKA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Tip, "TIP");
            Map(x => x.Opasni_Efekti, "OPASNI_EFEKTI");
            Map(x => x.Donja_Granica_Uzrasta, "DONJA_GRANICA_UZRASTA");

            References(x => x.Pripada_Predstavi).Column("ID_PREDSTAVE");

            HasManyToMany(x => x.Pomocno_Osoblje)
                .Table("ZADUZEN")
                .ParentKeyColumn("ID_TACKE")
                .ChildKeyColumn("ID_POMOCNOG_OSOBLJA")
                .Inverse()
                .Cascade.All();

            HasManyToMany(x => x.Artisti)
                .Table("ANGAZUJE_ARTISTU")
                .ParentKeyColumn("ID_TACKE")
                .ChildKeyColumn("ID_ARTISTE")
                .Cascade.All();

            HasManyToMany(x => x.Zivotinje)
                .Table("ANGAZUJE_ZIVOTINJE")
                .ParentKeyColumn("ID_TACKE")
                .ChildKeyColumn("ID_ZIVOTINJE")
                .Inverse()
                .Cascade.All();
        }
    }
}
