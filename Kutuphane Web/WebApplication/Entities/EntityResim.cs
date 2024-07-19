using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class EntityResim
    {
        public int ID { get; set; }

        public int? KullaniciID { get; set; }

        public bool? VarsayilanResim { get; set; }

        public byte[] Resim { get; set; }
    }
}