using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string KayitYapan { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public string DegisiklikYapan { get; set; }
        public DateTime? DegisiklikTarihi { get; set; }
        public IFormFile file { get; set; }
               
        public byte[] Resim { get; set; }
        
    }
}