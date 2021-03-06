//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Klasa Artikl.
    /// </summary>
    public partial class Artikl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artikl()
        {
            this.Dostupnost = new HashSet<Dostupnost>();
            this.Kompatibilnost = new HashSet<Kompatibilnost>();
            this.Kompatibilnost1 = new HashSet<Kompatibilnost>();
            this.StavkaDokumenta = new HashSet<StavkaDokumenta>();
        }
    
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Kratki_opis { get; set; }
        public string Specifikacija { get; set; }
        public double Cijena { get; set; }
        public int Vrsta_ID { get; set; }
    
        public virtual TipZaposlenika VrstaArtikla { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostupnost> Dostupnost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kompatibilnost> Kompatibilnost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kompatibilnost> Kompatibilnost1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaDokumenta> StavkaDokumenta { get; set; }

        /// <summary>
        /// Dohva�a sve artikle iz baze i vra�a ih u obliku liste.
        /// </summary>
        /// <returns>Lista artikala.</returns>
        public static BindingList<Artikl> DohvatiSveArtikle()
        {
            BindingList<Artikl> artikli = null;
            
            using (TechStoreEntities db = new TechStoreEntities())
            {
                artikli = new BindingList<Artikl>(db.Artikl.ToList());
            }

            return artikli;
        }

        /// <summary>
        /// Dohva�a komponente (artikle) na temelju upita iz baze i vra�a ih u obliku liste.
        /// </summary>
        /// <param name="upit">Upit na temelju kojeg se dohva�aju komponente iz baze.</param>
        /// <returns>Listu komponenata(artikala).</returns>
        public static List<Artikl> DohvatiKomponente(string upit)
        {
            List<Artikl> komponente = null;
            using (TechStoreEntities db = new TechStoreEntities())
            {
                komponente = db.Artikl.SqlQuery(upit).ToList();
            }

            return komponente;
        }

        /// <summary>
        /// Stati�ka metoda klase Artikl �ije je argument 
        /// novi artikl koji
        /// se sprema u bazu podataka.
        /// </summary>
        /// <param name="noviArtikl"></param>
        public static void DodajArtikl(Artikl noviArtikl) {
            using (var db=new TechStoreEntities())
            {
                db.Artikl.Add(noviArtikl);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Stati�ka metoda koja prima kao argument artikl koji
        /// se �eli obrisati. Metoda bri�e proslije�eni artikl
        /// iz baze podataka.
        /// </summary>
        /// <param name="artiklZaBrisanje"></param>
        public static void ObrisiArtikl(Artikl artiklZaBrisanje) {
            using (var db= new TechStoreEntities())
            {
                db.Artikl.Attach(artiklZaBrisanje);
                db.Kompatibilnost.RemoveRange(db.Kompatibilnost.Where(komp => komp.Komponenta1 == artiklZaBrisanje.ID));
                db.Artikl.Remove(artiklZaBrisanje);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Stati�ka metoda koja prima kao argument artikl koji 
        /// se �eli a�urirati te sve atribute u tablici.
        /// Metoda proslije�eni artikl
        /// a�urira i sprema u bazu podataka.
        /// </summary>
        /// <param name="artiklZaAzuriranje"></param>
        public static void AzurirajArtikl(Artikl artiklZaAzuriranje,string naziv, string kratkiOpis, string specifikacija, double cijena, int vrstaId)
        {
            using (var db= new TechStoreEntities())
            {
                db.Artikl.Attach(artiklZaAzuriranje);
                artiklZaAzuriranje.Naziv = naziv;
                artiklZaAzuriranje.Kratki_opis = kratkiOpis;
                artiklZaAzuriranje.Specifikacija = specifikacija;
                artiklZaAzuriranje.Cijena = cijena;
                artiklZaAzuriranje.Vrsta_ID = vrstaId;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Stati�ka metoda koja kao argument prima ID artikla.
        /// Metoda vra�a artikl s primljenim ID - om iz
        /// baze podataka.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Artikl DohvatiArtikl(int id) {
            Artikl artikl = null;
            using (var db= new TechStoreEntities())
            {
                 artikl = (from a in db.Artikl where a.ID == id select a).FirstOrDefault();
            }
            return artikl;
        }

        /// <summary>
        /// Metoda koja nadja�ava ToString metodu.
        /// </summary>
        /// <returns>Naziv artikla.</returns>
        public override string ToString()
        {
            return Naziv;
        }
    }
}
