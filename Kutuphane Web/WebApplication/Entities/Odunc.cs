using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Odunc
    {
        public int ID { get; set; }
        public int? KitapID { get; set; }
        public int? KullaniciID { get; set; }
        public int? GorevliID { get; set; }
        public string GorevliAdi { get; set; }
        public string KayitYapan { get; set; }
        public int? YazarID { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public DateTime? AlisTarihi { get; set; }

        public Nullable<bool> TeslimDurumu { get; set; }
        public string DegisiklikYapan { get; set; }
        public DateTime? DegisiklikTarihi { get; set; }
        public string KitapAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string SayfaSayisi { get; set; }
        public string Fiyat { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyad { get; set; }
        public string KategoriAdi { get; set; }
        public int? KategoriID { get; set; }
    }
}