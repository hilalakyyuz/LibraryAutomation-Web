using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Kitap
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int? KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public int? YazarID { get; set; }

        public string YayinYili { get; set; }
        public string SayfaSayisi { get; set; }
        public string Fiyat { get; set; }
        public string KayitYapan { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public string DegisiklikYapan { get; set; }
        public DateTime? DegisiklikTarihi { get; set; }
        public string Adyazar { get; set; }
        public string Adi { get; set; }
        public Yazar Yazarlar { get; set; }
        public Kategori Kategori { get; set; }
    }
}