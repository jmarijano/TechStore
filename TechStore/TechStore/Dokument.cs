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

    public partial class Dokument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dokument()
        {
            this.StanjeDokumenta = new HashSet<StanjeDokumenta>();
            this.StavkaDokumenta = new HashSet<StavkaDokumenta>();
        }
    
        public int ID { get; set; }
        public byte[] Vrijeme_izdavanja { get; set; }
        public int VrstaDokumenta_ID { get; set; }
    
        public virtual VrstaDokumenta VrstaDokumenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StanjeDokumenta> StanjeDokumenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StavkaDokumenta> StavkaDokumenta { get; set; }

        /// <summary>
        /// Stati�ka metoda koja kao argument prima novi dokument.
        /// Metoda sprema novi dokument u bazu podataka.
        /// </summary>
        /// <param name="noviDokument"></param>
        public static void DodajDokument(Dokument noviDokument)
        {
            using (var db = new TechStoreEntities())
            {
                db.Dokument.Attach(noviDokument);
                db.Dokument.Add(noviDokument);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Stati�ka metoda koja vra�a sve dokumente
        /// koji su narud�be.
        /// </summary>
        /// <returns></returns>
        public static BindingList<Dokument> DohvatiDokumente() {
            BindingList<Dokument> listadokumenata = null;
            using (var db= new TechStoreEntities())
            {
                listadokumenata = new BindingList<Dokument>(db.Dokument.SqlQuery("SELECT * FROM Dokument where VrstaDokumenta_ID=1").ToList());
            }
            return listadokumenata;
        }
    }
}
