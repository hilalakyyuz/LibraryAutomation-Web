using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Kategori
    {
        public string Adi { get; set; }
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string KayitYapan { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public string DegisiklikYapan { get; set; }
        public DateTime? DegisiklikTarihi { get; set; }
        public byte[]Resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odunc> OduncKitaplar { get; set; }

    }
}