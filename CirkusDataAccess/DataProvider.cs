using System;
using System.Collections.Generic;
using System.Linq;
using CirkusDataAccess.DTOs;
using CirkusDataAccess.Entiteti;
using NHibernate;

namespace CirkusDataAccess
{
    public class DataProvider
    {
        #region Artisti
        public static List<ArtistaView> VratiSveArtiste()
        {
            List<ArtistaView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Artista> svi_artisti = from a in s.Query<Artista>() select a;

                foreach (Artista a in svi_artisti)
                {
                    artisti.Add(new ArtistaView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static ArtistaView VratiArtistu(int id)
        {
            ArtistaView artista;
            try
            {
                ISession s = DataLayer.GetSession();

                Artista ar = s.Load<Artista>(id);
                artista = new ArtistaView(ar);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artista;
        }

        public static void ObrisiArtistuIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Artista a = s.Load<Artista>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Akrobate
        public static List<AkrobataView> VratiAkrobate()
        {
            List<AkrobataView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Akrobata> svi_artisti = from a in s.Query<Akrobata>() select a;

                foreach (Akrobata a in svi_artisti)
                {
                    AkrobataView akrobata = new(a);
                    akrobata.Poseduje_Vestine = VratiVestine(akrobata.Id);
                    artisti.Add(akrobata);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajAkrobatu(AkrobataView akrobata)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Akrobata a = new()
                {
                    Maticni_Broj = akrobata.Maticni_Broj,
                    Datum_Rodjenja = akrobata.Datum_Rodjenja,
                    Nadimak = akrobata.Nadimak,
                    Licno_Ime = akrobata.Licno_Ime,
                    Ime_Roditelja = akrobata.Ime_Roditelja,
                    Prezime = akrobata.Prezime,
                    Pocetak_Rada = akrobata.Pocetak_Rada,
                    Pol = akrobata.Pol,
                    Mesto_Rodjenja = akrobata.Mesto_Rodjenja,
                    Direktor = s.Load<Direktor>(akrobata.Direktor.Id)
                };

                s.SaveOrUpdate(a);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AkrobataView VratiAkrobatu(int id)
        {
            AkrobataView ak;
            try
            {
                ISession s = DataLayer.GetSession();

                Akrobata a = s.Load<Akrobata>(id);
                ak = new AkrobataView(a);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return ak;
        }

        public static AkrobataView AzurirajAkrobatu(AkrobataView akrobata)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Akrobata a = s.Load<Akrobata>(akrobata.Id);

                a.Maticni_Broj = akrobata.Maticni_Broj;
                a.Datum_Rodjenja = akrobata.Datum_Rodjenja;
                a.Nadimak = akrobata.Nadimak;
                a.Licno_Ime = akrobata.Licno_Ime;
                a.Ime_Roditelja = akrobata.Ime_Roditelja;
                a.Prezime = akrobata.Prezime;
                a.Pocetak_Rada = akrobata.Pocetak_Rada;
                a.Pol = akrobata.Pol;
                a.Mesto_Rodjenja = akrobata.Mesto_Rodjenja;

                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return akrobata;
        }
        public static void ObrisiAkrobatuIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Akrobata a = s.Load<Akrobata>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Vestine
        public static List<VestinaView> VratiVestine(int id_akrobate)
        {
            List<VestinaView> vestine = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Vestina> vest = from v in s.Query<Vestina>() where v.Akrobata.Id == id_akrobate select v;

                foreach (Vestina v in vest)
                {
                    vestine.Add(new VestinaView(v));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return vestine;
        }

        public static VestinaView VratiVestinu(int id)
        {
            VestinaView vestina;
            try
            {
                ISession s = DataLayer.GetSession();

                Vestina v = s.Load<Vestina>(id);
                vestina = new VestinaView(v);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return vestina;
        }

        public static VestinaView AzurirajVestinu(VestinaView vestina)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vestina v = new()
                {
                    Broj_Godina = vestina.Broj_Godina,
                    Naziv = vestina.Naziv,
                    Akrobata = s.Load<Akrobata>(vestina.Akrobata.Id)
                };

                v.Naziv = vestina.Naziv;
                v.Broj_Godina = vestina.Broj_Godina;

                s.Update(v);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return vestina;
        }

        public static VestinaView SacuvajVestinu(VestinaView vestina)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vestina v = s.Load<Vestina>(vestina.Id);

                v.Naziv = vestina.Naziv;
                v.Broj_Godina = vestina.Broj_Godina;

                s.SaveOrUpdate(v);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return vestina;
        }

        public static void ObrisiVestinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vestina v = s.Load<Vestina>(id);

                s.Delete(v);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region Asistenti
        public static List<AsistentiView> VratiAsistente(int id_artiste_sa_asistentima)
        {
            List<AsistentiView> asistenti = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Asistenti> asist = from v in s.Query<Asistenti>() where v.Artista_Sa_Asistentima.Id == id_artiste_sa_asistentima select v;

                foreach (Asistenti a in asist)
                {
                    AsistentiView asistent = DataProvider.VratiAsistenta(a.Id);
                    asistenti.Add(asistent);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return asistenti;
        }
        public static List<AsistentiView> VratiSveAsistente()
        {
            List<AsistentiView> asistenti = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Asistenti> asist = from v in s.Query<Asistenti>() select v;

                foreach (Asistenti a in asist)
                {
                    AsistentiView asistent = DataProvider.VratiAsistenta(a.Id);
                    asistenti.Add(asistent);
                }

                s.Close();
            }
            catch (Exception )
            {
                throw;
            }
            return asistenti;
        }
        public static void SacuvajAsistenta(AsistentiView asistent)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Asistenti a = new()
                {
                    Maticni_Broj = asistent.Maticni_Broj,
                    Datum_Rodjenja = asistent.Datum_Rodjenja,
                    Nadimak = asistent.Nadimak,
                    Licno_Ime = asistent.Licno_Ime,
                    Ime_Roditelja = asistent.Ime_Roditelja,
                    Prezime = asistent.Prezime,
                    Pocetak_Rada = asistent.Pocetak_Rada,
                    Pol = asistent.Pol,
                    Mesto_Rodjenja = asistent.Mesto_Rodjenja,
                    Direktor = s.Load<Direktor>(asistent.Direktor.Id),
                    Artista_Sa_Asistentima = s.Load<Asistenti>(asistent.Artista_Sa_Asistentima.Id)
                };

                s.SaveOrUpdate(a);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AsistentiView VratiAsistenta(int id)
        {
            AsistentiView ak;
            try
            {
                ISession s = DataLayer.GetSession();

                Asistenti a = s.Load<Asistenti>(id);
                ak = new AsistentiView(a);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return ak;
        }

        public static AsistentiView AzurirajAsistenta(AsistentiView asistent)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Asistenti a = s.Load<Asistenti>(asistent.Id);

                a.Maticni_Broj = asistent.Maticni_Broj;
                a.Datum_Rodjenja = asistent.Datum_Rodjenja;
                a.Nadimak = asistent.Nadimak;
                a.Licno_Ime = asistent.Licno_Ime;
                a.Ime_Roditelja = asistent.Ime_Roditelja;
                a.Prezime = asistent.Prezime;
                a.Pocetak_Rada = asistent.Pocetak_Rada;
                a.Pol = asistent.Pol;
                a.Mesto_Rodjenja = asistent.Mesto_Rodjenja;
                a.Artista_Sa_Asistentima = s.Load<Asistenti>(asistent.Artista_Sa_Asistentima.Id);

                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return asistent;
        }
        public static void ObrisiAsistentaIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Asistenti a = s.Load<Asistenti>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Bacaci_Nozeva
        public static List<BacaciNozevaView> VratiBacaceNozeva()
        {
            List<BacaciNozevaView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<BacaciNozeva> svi_artisti = from a in s.Query<BacaciNozeva>() select a;

                foreach (BacaciNozeva a in svi_artisti)
                {
                    BacaciNozevaView bn = new(a);
                    bn.Asistenti = VratiAsistente(bn.Id);
                    artisti.Add(bn);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajBacacaNozeva(BacaciNozevaView bacac_nozeva)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BacaciNozeva b = new()
                {
                    Maticni_Broj = bacac_nozeva.Maticni_Broj,
                    Datum_Rodjenja = bacac_nozeva.Datum_Rodjenja,
                    Nadimak = bacac_nozeva.Nadimak,
                    Licno_Ime = bacac_nozeva.Licno_Ime,
                    Ime_Roditelja = bacac_nozeva.Ime_Roditelja,
                    Prezime = bacac_nozeva.Prezime,
                    Pocetak_Rada = bacac_nozeva.Pocetak_Rada,
                    Pol = bacac_nozeva.Pol,
                    Mesto_Rodjenja = bacac_nozeva.Mesto_Rodjenja,
                    Direktor = s.Load<Direktor>(bacac_nozeva.Direktor.Id)
                };

                s.Save(b);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static BacaciNozevaView VratiBacacaNozeva(int id)
        {
            BacaciNozevaView bn;
            try
            {
                ISession s = DataLayer.GetSession();

                BacaciNozeva b = s.Load<BacaciNozeva>(id);
                bn = new BacaciNozevaView(b);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return bn;
        }

        public static BacaciNozevaView AzurirajBacacaNozeva(BacaciNozevaView bacac_nozeva)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BacaciNozeva b = s.Load<BacaciNozeva>(bacac_nozeva.Id);

                b.Maticni_Broj = bacac_nozeva.Maticni_Broj;
                b.Datum_Rodjenja = bacac_nozeva.Datum_Rodjenja;
                b.Nadimak = bacac_nozeva.Nadimak;
                b.Licno_Ime = bacac_nozeva.Licno_Ime;
                b.Ime_Roditelja = bacac_nozeva.Ime_Roditelja;
                b.Prezime = bacac_nozeva.Prezime;
                b.Pocetak_Rada = bacac_nozeva.Pocetak_Rada;
                b.Pol = bacac_nozeva.Pol;
                b.Mesto_Rodjenja = bacac_nozeva.Mesto_Rodjenja;

                s.Update(b);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return bacac_nozeva;
        }
        public static void ObrisiBacacaNozevaIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                BacaciNozeva a = s.Load<BacaciNozeva>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Dreseri
        public static void ObrisiDreseraIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Dreseri a = s.Load<Dreseri>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<DreseriView> VratiDresere()
        {
            List<DreseriView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Dreseri> svi_artisti = from a in s.Query<Dreseri>() select a;

                foreach (Dreseri a in svi_artisti)
                {
                    DreseriView d = new(a);
                    d.Asistenti = VratiAsistente(d.Id);
                    d.Dresira = VratiZivotinjeDresera(d.Id);
                    artisti.Add(d);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajDresera(DreseriView dreser)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Dreseri d = new()
                {
                    Maticni_Broj = dreser.Maticni_Broj,
                    Datum_Rodjenja = dreser.Datum_Rodjenja,
                    Nadimak = dreser.Nadimak,
                    Licno_Ime = dreser.Licno_Ime,
                    Ime_Roditelja = dreser.Ime_Roditelja,
                    Prezime = dreser.Prezime,
                    Pocetak_Rada = dreser.Pocetak_Rada,
                    Pol = dreser.Pol,
                    Mesto_Rodjenja = dreser.Mesto_Rodjenja,
                    Direktor = s.Load<Direktor>(dreser.Direktor.Id)
                };

                s.SaveOrUpdate(d);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DreseriView VratiDresera(int id)
        {
            DreseriView dr;
            try
            {
                ISession s = DataLayer.GetSession();

                Dreseri d = s.Load<Dreseri>(id);
                dr = new DreseriView(d);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return dr;
        }

        public static DreseriView AzurirajDresera(DreseriView dreser)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Dreseri d = s.Load<Dreseri>(dreser.Id);

                d.Maticni_Broj = dreser.Maticni_Broj;
                d.Datum_Rodjenja = dreser.Datum_Rodjenja;
                d.Nadimak = dreser.Nadimak;
                d.Licno_Ime = dreser.Licno_Ime;
                d.Ime_Roditelja = dreser.Ime_Roditelja;
                d.Prezime = dreser.Prezime;
                d.Pocetak_Rada = dreser.Pocetak_Rada;
                d.Pol = dreser.Pol;
                d.Mesto_Rodjenja = dreser.Mesto_Rodjenja;

                s.Update(d);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return dreser;
        }
        #endregion

        #region Gutaci_Plamena
        public static void ObrisiGutacaPlamenaIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GutaciPlamena a = s.Load<GutaciPlamena>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<GutaciPlamenaView> VratiGutacePlamena()
        {
            List<GutaciPlamenaView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GutaciPlamena> svi_artisti = from a in s.Query<GutaciPlamena>() select a;

                foreach (GutaciPlamena a in svi_artisti)
                {
                    GutaciPlamenaView gutac = new(a);
                    gutac.Asistenti = VratiAsistente(gutac.Id);
                    artisti.Add(gutac);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajGutacaPlamena(GutaciPlamenaView gutaci_plamena)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GutaciPlamena gp = new()
                {
                    Maticni_Broj = gutaci_plamena.Maticni_Broj,
                    Datum_Rodjenja = gutaci_plamena.Datum_Rodjenja,
                    Nadimak = gutaci_plamena.Nadimak,
                    Licno_Ime = gutaci_plamena.Licno_Ime,
                    Ime_Roditelja = gutaci_plamena.Ime_Roditelja,
                    Prezime = gutaci_plamena.Prezime,
                    Pocetak_Rada = gutaci_plamena.Pocetak_Rada,
                    Pol = gutaci_plamena.Pol,
                    Mesto_Rodjenja = gutaci_plamena.Mesto_Rodjenja,
                    Direktor = s.Load<Direktor>(gutaci_plamena.Direktor.Id)
                };

                s.SaveOrUpdate(gp);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static GutaciPlamenaView VratiGutacaPlamena(int id)
        {
            GutaciPlamenaView gp;
            try
            {
                ISession s = DataLayer.GetSession();

                GutaciPlamena g = s.Load<GutaciPlamena>(id);
                gp = new GutaciPlamenaView(g);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return gp;
        }

        public static GutaciPlamenaView AzurirajGutacaPlamena(GutaciPlamenaView gutac_plamena)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GutaciPlamena gp = s.Load<GutaciPlamena>(gutac_plamena.Id);

                gp.Maticni_Broj = gutac_plamena.Maticni_Broj;
                gp.Datum_Rodjenja = gutac_plamena.Datum_Rodjenja;
                gp.Nadimak = gutac_plamena.Nadimak;
                gp.Licno_Ime = gutac_plamena.Licno_Ime;
                gp.Ime_Roditelja = gutac_plamena.Ime_Roditelja;
                gp.Prezime = gutac_plamena.Prezime;
                gp.Pocetak_Rada = gutac_plamena.Pocetak_Rada;
                gp.Pol = gutac_plamena.Pol;
                gp.Mesto_Rodjenja = gutac_plamena.Mesto_Rodjenja;

                s.Update(gp);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return gutac_plamena;
        }
        #endregion

        #region Klovnovi
        public static void ObrisiKlovnaIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klovn a = s.Load<Klovn>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<KlovnView> VratiKlovnove()
        {
            List<KlovnView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Klovn> svi_artisti = from a in s.Query<Klovn>() select a;

                foreach (Klovn a in svi_artisti)
                {
                    artisti.Add(new KlovnView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajKlovna(KlovnView klovn)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klovn k = new()
                {
                    Maticni_Broj = klovn.Maticni_Broj,
                    Datum_Rodjenja = klovn.Datum_Rodjenja,
                    Nadimak = klovn.Nadimak,
                    Licno_Ime = klovn.Licno_Ime,
                    Ime_Roditelja = klovn.Ime_Roditelja,
                    Prezime = klovn.Prezime,
                    Pocetak_Rada = klovn.Pocetak_Rada,
                    Pol = klovn.Pol,
                    Mesto_Rodjenja = klovn.Mesto_Rodjenja,
                    Tip = klovn.Tip,
                    Predmet_Za_Zabavu = klovn.Predmet_Za_Zabavu,
                    Direktor = s.Load<Direktor>(klovn.Direktor.Id)
                };

                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static KlovnView VratiKlovna(int id)
        {
            KlovnView kl;
            try
            {
                ISession s = DataLayer.GetSession();

                Klovn k = s.Load<Klovn>(id);
                kl = new KlovnView(k);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return kl;
        }

        public static KlovnView AzurirajKlovna(KlovnView klovn)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klovn k = s.Load<Klovn>(klovn.Id);

                k.Maticni_Broj = klovn.Maticni_Broj;
                k.Datum_Rodjenja = klovn.Datum_Rodjenja;
                k.Nadimak = klovn.Nadimak;
                k.Licno_Ime = klovn.Licno_Ime;
                k.Ime_Roditelja = klovn.Ime_Roditelja;
                k.Prezime = klovn.Prezime;
                k.Pocetak_Rada = klovn.Pocetak_Rada;
                k.Pol = klovn.Pol;
                k.Mesto_Rodjenja = klovn.Mesto_Rodjenja;
                k.Tip = klovn.Tip;
                k.Predmet_Za_Zabavu = klovn.Predmet_Za_Zabavu;

                s.Update(k);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return klovn;
        }
        #endregion

        #region Zongleri
        public static void ObrisiZongleraIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zongler a = s.Load<Zongler>(id);

                s.Delete(a);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<ZonglerView> VratiZonglere()
        {
            List<ZonglerView> artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zongler> svi_artisti = from a in s.Query<Zongler>() select a;

                foreach (Zongler a in svi_artisti)
                {
                    artisti.Add(new ZonglerView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return artisti;
        }
        public static void SacuvajZonglera(ZonglerView zongler)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zongler z = new()
                {
                    Maticni_Broj = zongler.Maticni_Broj,
                    Datum_Rodjenja = zongler.Datum_Rodjenja,
                    Nadimak = zongler.Nadimak,
                    Licno_Ime = zongler.Licno_Ime,
                    Ime_Roditelja = zongler.Ime_Roditelja,
                    Prezime = zongler.Prezime,
                    Pocetak_Rada = zongler.Pocetak_Rada,
                    Pol = zongler.Pol,
                    Mesto_Rodjenja = zongler.Mesto_Rodjenja,
                    Naziv = zongler.Naziv,
                    Broj_Predmeta = zongler.Broj_Predmeta,
                    Direktor = s.Load<Direktor>(zongler.Direktor.Id)
                };

                s.SaveOrUpdate(z);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ZonglerView VratiZonglera(int id)
        {
            ZonglerView zg;
            try
            {
                ISession s = DataLayer.GetSession();

                Zongler z = s.Load<Zongler>(id);
                zg = new ZonglerView(z);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zg;
        }

        public static ZonglerView AzurirajZonglera(ZonglerView zongler)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zongler z = s.Load<Zongler>(zongler.Id);

                z.Maticni_Broj = zongler.Maticni_Broj;
                z.Datum_Rodjenja = zongler.Datum_Rodjenja;
                z.Nadimak = zongler.Nadimak;
                z.Licno_Ime = zongler.Licno_Ime;
                z.Ime_Roditelja = zongler.Ime_Roditelja;
                z.Prezime = zongler.Prezime;
                z.Pocetak_Rada = zongler.Pocetak_Rada;
                z.Pol = zongler.Pol;
                z.Mesto_Rodjenja = zongler.Mesto_Rodjenja;
                z.Naziv = zongler.Naziv;
                z.Broj_Predmeta = zongler.Broj_Predmeta;

                s.Update(z);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zongler;
        }
        #endregion

        #endregion

        #region Angazuje_Artistu
        public static List<AngazujeArtistuView> VratiAngazovaneArtiste(int cirkuska_tacka_id)
        {
            List<AngazujeArtistuView> angazovani_artisti = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<AngazujeArtistu> artisti = from a in s.Query<AngazujeArtistu>() where a.Cirkuska_Tacka.Id == cirkuska_tacka_id select a;

                foreach (AngazujeArtistu a in artisti)
                {
                    angazovani_artisti.Add(new AngazujeArtistuView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return angazovani_artisti;
        }

        public static void ObrisiArtistu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AngazujeArtistu artista = s.Load<AngazujeArtistu>(id);

                s.Delete(artista);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SacuvajAngazujeArtistu(AngazujeArtistuView a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AngazujeArtistu an = new()
                {
                    Artista = s.Load<Artista>(a.Artista.Id),
                    Cirkuska_Tacka = s.Load<CirkuskaTacka>(a.Cirkuska_Tacka.Id)
                };

                s.Save(an);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Angazuje_Zivotinju
        public static List<AngazujeZivotinjuView> VratiAngazovaneZivotinje(int cirkuska_tacka_id)
        {
            List<AngazujeZivotinjuView> angazovane_zivotinje = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<AngazujeZivotinju> zivotinje = from a in s.Query<AngazujeZivotinju>() where a.Cirkuska_Tacka.Id == cirkuska_tacka_id select a;

                foreach (AngazujeZivotinju a in zivotinje)
                {
                    angazovane_zivotinje.Add(new AngazujeZivotinjuView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return angazovane_zivotinje;
        }

        public static void ObrisiAngazujeZivotinju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AngazujeZivotinju zivotinja = s.Load<AngazujeZivotinju>(id);

                s.Delete(zivotinja);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SacuvajAngazujeZivotinju(AngazujeZivotinjuView z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AngazujeZivotinju an = new()
                {
                    Zivotinja = s.Load<Zivotinja>(z.Zivotinja.Id),
                    Cirkuska_Tacka = s.Load<CirkuskaTacka>(z.Cirkuska_Tacka.Id)
                };

                s.Save(an);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Cirkuske_Tacke
        public static List<CirkuskaTackaView> VratiCirkuskeTackePredstave(int id_predstave)
        {
            List<CirkuskaTackaView> cirkuske_tacke = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<CirkuskaTacka> svi_artisti = from a in s.Query<CirkuskaTacka>() where a.Pripada_Predstavi.Id == id_predstave select a;

                foreach (CirkuskaTacka ct in svi_artisti)
                {
                    cirkuske_tacke.Add(new CirkuskaTackaView(ct));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cirkuske_tacke;
        }
        public static List<CirkuskaTackaView> VratiCirkuskeTacke()
        {
            List<CirkuskaTackaView> cirkuske_tacke = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<CirkuskaTacka> sve_tacke = from a in s.Query<CirkuskaTacka>() select a;

                foreach (CirkuskaTacka ct in sve_tacke)
                {
                    CirkuskaTackaView tacka = new(ct);
                    IList<AngazujeArtistuView> artisti = VratiAngazovaneArtiste(tacka.Id);
                    foreach(AngazujeArtistuView artista in artisti)
                    {
                        tacka.Artisti.Add(artista.Artista);
                    }
                    IList<AngazujeZivotinjuView> zivotinje = VratiAngazovaneZivotinje(tacka.Id);
                    foreach (AngazujeZivotinjuView zivotinja in zivotinje)
                    {
                        tacka.Zivotinje.Add(zivotinja.Zivotinja);
                    }
                    IList<ZaduzenView> osoblje = VratiZaduzeneOsobe(tacka.Id);
                    foreach (ZaduzenView osoba in osoblje)
                    {
                        tacka.Pomocno_Osoblje.Add(osoba.Pomocno_Osoblje);
                    }
                    cirkuske_tacke.Add(tacka);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cirkuske_tacke;
        }
        public static CirkuskaTackaView VratiCirkuskuTacku(int id)
        {
            CirkuskaTackaView cirkuska_tacka;
            try
            {
                ISession s = DataLayer.GetSession();

                CirkuskaTacka ct = s.Load<CirkuskaTacka>(id);
                cirkuska_tacka = new CirkuskaTackaView(ct);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return cirkuska_tacka;
        }
        public static void ObrisiCirkuskuTackuIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CirkuskaTacka ct = s.Load<CirkuskaTacka>(id);

                s.Delete(ct);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajCirkuskuTacku(CirkuskaTackaView cirkuska_tacka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CirkuskaTacka ct = new()
                {
                    Ime = cirkuska_tacka.Ime,
                    Tip = cirkuska_tacka.Tip,
                    Opasni_Efekti = cirkuska_tacka.Opasni_Efekti,
                    Donja_Granica_Uzrasta = cirkuska_tacka.Donja_Granica_Uzrasta,
                    Pripada_Predstavi = s.Load<Predstava>(cirkuska_tacka.Pripada_Predstavi.Id)
                };

                s.SaveOrUpdate(ct);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CirkuskaTackaView AzurirajCirkuskuTacku(CirkuskaTackaView cirkuska_tacka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CirkuskaTacka ct = s.Load<CirkuskaTacka>(cirkuska_tacka.Id);

                ct.Ime = cirkuska_tacka.Ime;
                ct.Tip = cirkuska_tacka.Tip;
                ct.Opasni_Efekti = cirkuska_tacka.Opasni_Efekti;
                ct.Donja_Granica_Uzrasta = cirkuska_tacka.Donja_Granica_Uzrasta;

                s.Update(ct);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return cirkuska_tacka;
        }
        #endregion

        #region Direktori
        public static List<DirektorView> VratiSveDirektore()
        {
            List<DirektorView> direktori = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Direktor> direkt = from d in s.Query<Direktor>() select d;

                foreach (Direktor d in direkt)
                {
                    DirektorView direktor = DataProvider.VratiDirektora(d.Id);
                    direktor.Brojevi_Telefona = VratiTelefoneDirektora(direktor.Id);
                    direktor.Emailovi = VratiEmailoveDirektora(direktor.Id);
                    direktori.Add(direktor);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return direktori;
        }
        public static DirektorView VratiDirektora(int id)
        {
            DirektorView direktor;
            try
            {
                ISession s = DataLayer.GetSession();

                Direktor dt = s.Load<Direktor>(id);
                direktor = new DirektorView(dt);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return direktor;
        }
        public static void ObrisiDirektora(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Direktor dt = s.Load<Direktor>(id);

                s.Delete(dt);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajDirektora(DirektorView direktor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Direktor dt = new()
                {
                    Licno_Ime = direktor.Licno_Ime,
                    Srednje_Slovo = direktor.Srednje_Slovo,
                    Prezime = direktor.Prezime
                };

                s.SaveOrUpdate(dt);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DirektorView AzurirajDirektora(DirektorView direktor)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Direktor dt = s.Load<Direktor>(direktor.Id);

                dt.Licno_Ime = direktor.Licno_Ime;
                dt.Srednje_Slovo = direktor.Srednje_Slovo;
                dt.Prezime = direktor.Prezime;

                s.Update(dt);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return direktor;
        }

        #region Telefoni_Direktora
        public static IList<TelefonDirektoraView> VratiTelefoneDirektora(int id_direktora)
        {
            List<TelefonDirektoraView> telefoni_direktora = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<TelefonDirektora> svi_telefoni = from a in s.Query<TelefonDirektora>() where a.Direktor.Id == id_direktora select a;

                foreach (TelefonDirektora td in svi_telefoni)
                {
                    telefoni_direktora.Add(new TelefonDirektoraView(td));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return telefoni_direktora;
        }
        public static void ObrisiTelefon(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonDirektora td = s.Load<TelefonDirektora>(id);

                s.Delete(td);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajTelefon(TelefonDirektoraView telefon)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonDirektora td = new()
                {
                    Direktor = s.Load<Direktor>(telefon.Direktor.Id),
                    Broj_Telefona = telefon.Broj_Telefona
                };

                s.SaveOrUpdate(td);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static TelefonDirektoraView AzurirajBrojTelefona(TelefonDirektoraView telefon)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonDirektora td = s.Load<TelefonDirektora>(telefon.Id);

                td.Broj_Telefona = telefon.Broj_Telefona;

                s.Update(td);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return telefon;
        }
        #endregion

        #region Emailovi_Direktora
        public static IList<EmailDirektoraView> VratiEmailoveDirektora(int id_direktora)
        {
            List<EmailDirektoraView> emailovi_direktora = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<EmailDirektora> svi_emailovi = from a in s.Query<EmailDirektora>() where a.Direktor.Id == id_direktora select a;

                foreach (EmailDirektora a in svi_emailovi)
                {
                    emailovi_direktora.Add(new EmailDirektoraView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return emailovi_direktora;
        }
        public static void ObrisiEmail(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                EmailDirektora ed = s.Load<EmailDirektora>(id);

                s.Delete(ed);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajEmail(EmailDirektoraView email)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                EmailDirektora ed = new()
                {
                    Direktor = s.Load<Direktor>(email.Direktor.Id),
                    Email = email.Email
                };

                s.SaveOrUpdate(ed);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static EmailDirektoraView AzurirajEmail(EmailDirektoraView email)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                EmailDirektora ed = s.Load<EmailDirektora>(email.Id);

                ed.Email = email.Email;

                s.Update(ed);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return email;
        }
        #endregion

        #endregion

        #region Gradovi
        public static List<GradView> VratiSveGradoveBasic()
        {
            List<GradView> gradovi = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Grad> grad = from d in s.Query<Grad>() select d;

                foreach (Grad d in grad)
                {
                    GradView g = DataProvider.VratiGrad(d.Id);
                    
                    gradovi.Add(g);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return gradovi;
        }
        public static GradView VratiGrad(int id)
        {
            GradView grad;
            try
            {
                ISession s = DataLayer.GetSession();

                Grad gr = s.Load<Grad>(id);
                grad = new GradView(gr);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return grad;
        }
        public static void ObrisiGrad(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grad gr = s.Load<Grad>(id);

                s.Delete(gr);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajGrad(GradView grad)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grad dt = new()
                {
                    Naziv_Drzave = grad.Naziv_Drzave,
                    Naziv_Grada = grad.Naziv_Grada,
                    Datum_Od = grad.Datum_Od,
                    Datum_Do = grad.Datum_Do
                };

                s.SaveOrUpdate(dt);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static GradView AzurirajGrad(GradView grad)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Grad gr = s.Load<Grad>(grad.Id);

                gr.Naziv_Drzave = grad.Naziv_Drzave;
                gr.Naziv_Grada = grad.Naziv_Grada;
                gr.Datum_Od = grad.Datum_Od;
                gr.Datum_Do = grad.Datum_Do;
                gr.Opis = grad.Opis;

                s.Update(gr);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return grad;
        }
        #endregion

        #region Grad_Predstava
        public static List<GradPredstavaView> VratiGradoveSaPredstavama(int grad_id)
        {
            List<GradPredstavaView> grad_predstava = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<GradPredstava> gradovi = from a in s.Query<GradPredstava>() where a.Grad.Id == grad_id select a;

                foreach (GradPredstava g in gradovi)
                {
                    grad_predstava.Add(new GradPredstavaView(g));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return grad_predstava;
        }

        public static void ObrisiGradPredstava(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GradPredstava grad_predstava = s.Load<GradPredstava>(id);

                s.Delete(grad_predstava);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SacuvajGradPredstava(GradPredstavaView gp)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                GradPredstava grad_predstava = new()
                {
                    Grad = s.Load<Grad>(gp.Grad.Id),
                    Predstava = s.Load<Predstava>(gp.Predstava.Id)
                };

                s.Save(grad_predstava);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Pomocno_Osoblje
        public static List<PomocnoOsobljeView> VratiPomocnoOsobljeBasic()
        {
            List<PomocnoOsobljeView> pomocno_osoblje = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<PomocnoOsoblje> pomocne_osobe = from p in s.Query<PomocnoOsoblje>() select p;

                foreach (PomocnoOsoblje po in pomocne_osobe)
                {
                    pomocno_osoblje.Add(new PomocnoOsobljeView(po));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return pomocno_osoblje;
        }
        public static PomocnoOsobljeView VratiPomocnuOsobu(int id)
        {
            PomocnoOsobljeView pomocna_osoba;
            try
            {
                ISession s = DataLayer.GetSession();

                PomocnoOsoblje po = s.Load<PomocnoOsoblje>(id);
                pomocna_osoba = new PomocnoOsobljeView(po);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return pomocna_osoba;
        }
        public static void ObrisiPomocnuOsobu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PomocnoOsoblje po = s.Load<PomocnoOsoblje>(id);

                s.Delete(po);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajPomocnuOsobu(PomocnoOsobljeView pomocno_osoblje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PomocnoOsoblje dt = new()
                {
                    Maticni_Broj = pomocno_osoblje.Maticni_Broj,
                    Licno_Ime = pomocno_osoblje.Licno_Ime,
                    Srednje_Slovo = pomocno_osoblje.Srednje_Slovo,
                    Prezime = pomocno_osoblje.Prezime,
                    Pol = pomocno_osoblje.Pol,
                    Mesto_Rodjenja = pomocno_osoblje.Mesto_Rodjenja,
                    Datum_Rodjenja = pomocno_osoblje.Datum_Rodjenja,
                    Direktor = s.Load<Direktor>(pomocno_osoblje.Direktor.Id)
                };

                s.SaveOrUpdate(dt);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PomocnoOsobljeView AzurirajPomocnuOsobu(PomocnoOsobljeView pomocna_osoba)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PomocnoOsoblje po = s.Load<PomocnoOsoblje>(pomocna_osoba.Id);

                po.Maticni_Broj = pomocna_osoba.Maticni_Broj;
                po.Licno_Ime = pomocna_osoba.Licno_Ime;
                po.Srednje_Slovo = pomocna_osoba.Srednje_Slovo;
                po.Prezime = pomocna_osoba.Prezime;
                po.Pol = pomocna_osoba.Pol;
                po.Mesto_Rodjenja = pomocna_osoba.Mesto_Rodjenja;
                po.Datum_Rodjenja = pomocna_osoba.Datum_Rodjenja;
                po.Direktor = s.Load<Direktor>(pomocna_osoba.Direktor.Id);

                s.Update(po);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return pomocna_osoba;
        }
        #endregion

        #region Predstave
        public static void ObrisiPredstavu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predstava predstava = s.Load<Predstava>(id);

                s.Delete(predstava);
                s.Flush();

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #region Redovna_Predstava
        public static List<RedovnaPredstavaView> VratiRedovnePredstave()
        {
            List<RedovnaPredstavaView> redovne_predstave = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RedovnaPredstava> predstave = from p in s.Query<RedovnaPredstava>() select p;

                foreach (RedovnaPredstava p in predstave)
                {
                    RedovnaPredstavaView predstava = new(p);
                    predstava.Cirkuske_Tacke = VratiCirkuskeTackePredstave(predstava.Id);
                    redovne_predstave.Add(predstava);
                }

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return redovne_predstave;
        }
        public static void DodajRedovnuPredstavu()
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RedovnaPredstava p = new()
                {
                    Razlog_Organizovanja = null,
                    Prihod = null,
                    Namenjen_Prihod = null,
                    Naziv = null,
                    Adresa = null,
                    Brojevi_Telefona_Narucioca = null
                };

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Humanitarna_Predstava
        public static List<HumanitarnaPredstavaView> VratiHumanitarnePredstave()
        {
            List<HumanitarnaPredstavaView> humanitarne_predstave = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<HumanitarnaPredstava> predstave = from p in s.Query<HumanitarnaPredstava>() where p.Razlog_Organizovanja == 0 select p;

                foreach (HumanitarnaPredstava p in predstave)
                {
                    humanitarne_predstave.Add(new HumanitarnaPredstavaView(p));
                }

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return humanitarne_predstave;
        }

        public static HumanitarnaPredstavaView VratiHumanitarnuPredstavu(int id)
        {
            HumanitarnaPredstavaView predstava;
            try
            {
                ISession s = DataLayer.GetSession();

                HumanitarnaPredstava pr = s.Load<HumanitarnaPredstava>(id);
                predstava = new HumanitarnaPredstavaView(pr);
                predstava.Cirkuske_Tacke = VratiCirkuskeTackePredstave(predstava.Id);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return predstava;
        }
        public static void DodajHumanitarnuPredstavu(HumanitarnaPredstavaView predstava)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                HumanitarnaPredstava p = new()
                {
                    Razlog_Organizovanja = 0,
                    Prihod = predstava.Prihod,
                    Namenjen_Prihod = predstava.Namenjen_Prihod,
                    Naziv = null,
                    Adresa = null,
                    Brojevi_Telefona_Narucioca = null
                };

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AzurirajHumanitarnuPredstavu(HumanitarnaPredstavaView predstava)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                HumanitarnaPredstava p = s.Load<HumanitarnaPredstava>(predstava.Id);

                p.Prihod = predstava.Prihod;
                p.Namenjen_Prihod = predstava.Namenjen_Prihod;

                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Narucena_Predstava
        public static List<NarucenaPredstavaView> VratiNarucenePredstave()
        {
            List<NarucenaPredstavaView> narucene_predstave = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NarucenaPredstava> predstave = from p in s.Query<NarucenaPredstava>() where p.Razlog_Organizovanja == 1 select p;

                foreach (NarucenaPredstava p in predstave)
                {
                    NarucenaPredstavaView predstava = new(p);
                    predstava.Brojevi_Telefona_Narucioca = VratiTelefoneNarucioca(predstava.Id);
                    narucene_predstave.Add(predstava);
                }

                s.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return narucene_predstave;
        }

        public static NarucenaPredstavaView VratiNarucenuPredstavu(int id)
        {
            NarucenaPredstavaView predstava;
            try
            {
                ISession s = DataLayer.GetSession();

                NarucenaPredstava pr = s.Load<NarucenaPredstava>(id);
                predstava = new NarucenaPredstavaView(pr);
                predstava.Brojevi_Telefona_Narucioca = VratiTelefoneNarucioca(predstava.Id);
                predstava.Cirkuske_Tacke = VratiCirkuskeTackePredstave(predstava.Id);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return predstava;
        }
        public static void DodajNarucenuPredstavu(NarucenaPredstavaView predstava)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NarucenaPredstava p = new()
                {
                    Razlog_Organizovanja = 1,
                    Prihod = null,
                    Namenjen_Prihod = null,
                    Naziv = predstava.Naziv,
                    Adresa = predstava.Adresa,
                    Brojevi_Telefona_Narucioca = new List<TelefonNarucioca>()
                };

                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AzurirajNarucenuPredstavu(NarucenaPredstavaView predstava)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NarucenaPredstava p = s.Load<NarucenaPredstava>(predstava.Id);

                p.Naziv = predstava.Naziv;
                p.Adresa = predstava.Adresa;

                s.SaveOrUpdate(p);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Telefoni_Narucioca
        public static List<TelefonNaruciocaView> VratiTelefoneNarucioca(int id_predstave)
        {
            List<TelefonNaruciocaView> telefoni_narucioca = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<TelefonNarucioca> svi_telefoni = from a in s.Query<TelefonNarucioca>() where a.Narucioc_Predstave.Id == id_predstave select a;

                foreach (TelefonNarucioca tn in svi_telefoni)
                {
                    telefoni_narucioca.Add(new TelefonNaruciocaView(tn));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return telefoni_narucioca;
        }
        public static void ObrisiTelefonNarucioca(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonNarucioca tn = s.Load<TelefonNarucioca>(id);

                s.Delete(tn);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajTelefonNarucioca(TelefonNaruciocaView telefon)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonNarucioca tn = new()
                {
                    Narucioc_Predstave = s.Load<Predstava>(telefon.Narucioc_Predstave.Id),
                    Broj_Telefona = telefon.Broj_Telefona
                };

                s.SaveOrUpdate(tn);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static TelefonNaruciocaView AzurirajBrojTelefonaNarucioca(TelefonNaruciocaView telefon)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TelefonNarucioca tn = s.Load<TelefonNarucioca>(telefon.Id);

                tn.Broj_Telefona = telefon.Broj_Telefona;

                s.Update(tn);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return telefon;
        }
        #endregion

        #endregion

        #region Zaduzen
        public static List<ZaduzenView> VratiZaduzeneOsobe(int cirkuska_tacka_id)
        {
            List<ZaduzenView> zaduzeno_osoblje = new();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Zaduzen> zaduzeni = from a in s.Query<Zaduzen>() where a.Cirkuska_Tacka.Id == cirkuska_tacka_id select a;

                foreach (Zaduzen a in zaduzeni)
                {
                    zaduzeno_osoblje.Add(new ZaduzenView(a));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zaduzeno_osoblje;
        }

        public static void ObrisiZaduzenuOsobu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaduzen zaduzena_osoba = s.Load<Zaduzen>(id);

                s.Delete(zaduzena_osoba);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SacuvajZaduzenuOsobu(ZaduzenView z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaduzen zaduzen = new()
                {
                    Pomocno_Osoblje = s.Load<PomocnoOsoblje>(z.Pomocno_Osoblje.Id),
                    Cirkuska_Tacka = s.Load<CirkuskaTacka>(z.Cirkuska_Tacka.Id)
                };

                s.Save(zaduzen);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Zivotinje
        public static List<ZivotinjaView> VratiZivotinjeDresera(int id_dresera)
        {
            List<ZivotinjaView> zivotinje = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Zivotinja> ziv = from v in s.Query<Zivotinja>() where v.Dreser.Id == id_dresera select v;

                foreach (Zivotinja z in ziv)
                {
                    ZivotinjaView zivotinja = DataProvider.VratiZivotinju(z.Id);
                    zivotinje.Add(zivotinja);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zivotinje;
        }
        public static List<ZivotinjaView> VratiZivotinje()
        {
            List<ZivotinjaView> zivotinje = new();

            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Zivotinja> ziv = from d in s.Query<Zivotinja>() select d;

                foreach (Zivotinja po in ziv)
                {
                    ZivotinjaView p = DataProvider.VratiZivotinju(po.Id);
                    zivotinje.Add(p);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zivotinje;
        }
        public static ZivotinjaView VratiZivotinju(int id)
        {
            ZivotinjaView zivotinja;
            try
            {
                ISession s = DataLayer.GetSession();

                Zivotinja zi = s.Load<Zivotinja>(id);
                zivotinja = new ZivotinjaView(zi);

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return zivotinja;
        }
        public static void ObrisiZivotinju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zivotinja po = s.Load<Zivotinja>(id);

                s.Delete(po);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void DodajZivotinju(ZivotinjaView zivotinja)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zivotinja zv = new()
                {
                    Nadimak = zivotinja.Nadimak,
                    Vrsta = zivotinja.Vrsta,
                    Pol = zivotinja.Pol,
                    Starost = zivotinja.Starost,
                    Vreme_Boravka = zivotinja.Vreme_Boravka,
                    Datum_Veterinarskog_Pregleda = zivotinja.Datum_Veterinarskog_Pregleda,
                    Broj_Kaveza = zivotinja.Broj_Kaveza,
                    Tezina = zivotinja.Tezina,
                    Dreser = s.Load<Dreseri>(zivotinja.Dreser.Id),
                    Direktor = s.Load<Direktor>(zivotinja.Direktor.Id)
                };

                s.SaveOrUpdate(zv);

                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ZivotinjaView AzurirajZivotinju(ZivotinjaView zivotinja)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zivotinja zv = s.Load<Zivotinja>(zivotinja.Id);

                zv.Nadimak = zivotinja.Nadimak;
                zv.Vrsta = zivotinja.Vrsta;
                zv.Pol = zivotinja.Pol;
                zv.Starost = zivotinja.Starost;
                zv.Vreme_Boravka = zivotinja.Vreme_Boravka;
                zv.Datum_Veterinarskog_Pregleda = zivotinja.Datum_Veterinarskog_Pregleda;
                zv.Broj_Kaveza = zivotinja.Broj_Kaveza;
                zv.Tezina = zivotinja.Tezina;
                zv.Dreser = s.Load<Dreseri>(zivotinja.Dreser.Id);
                zv.Direktor = s.Load<Direktor>(zivotinja.Direktor.Id);

                s.Update(zv);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return zivotinja;
        }
        #endregion
    }
}
