using CirkusDataAccess.Entiteti;
using System;
using System.Collections.Generic;

namespace CirkusDataAccess.DTOs
{
    public class GradView
    {
        public int Id { get; protected set; }
        public string Naziv_Drzave { get; set; }
        public string Naziv_Grada { get; set; }
        public DateTime Datum_Od { get; set; }
        public DateTime Datum_Do { get; set; }
        public string Opis { get; set; }

        public IList<PredstavaView> Predstave { get; set; }

        public GradView()
        {
            Predstave = new List<PredstavaView>();
        }

        public GradView(Grad g)
        {
            Id = g.Id;
            Naziv_Drzave = g.Naziv_Drzave;
            Naziv_Grada = g.Naziv_Grada;
            Datum_Od = g.Datum_Od;
            Datum_Do = g.Datum_Do;
            Opis = g.Opis;
        }
    }
}
