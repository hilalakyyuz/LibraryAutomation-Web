using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Gorevli
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string KayitYapan { get; set; }
        public string DegisiklikYapan { get; set; }
        public Nullable<System.DateTime> DegisiklikTarihi { get; set; }
    }
}