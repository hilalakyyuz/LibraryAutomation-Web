using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        public ActionResult Index()
        {
            var kitaplar = ApiKitap.KitapListe();
            return View(kitaplar);
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await ApiKitap.KitapSil(id);
            }
            catch (Exception ex)
            {
                
                return Content(ex.Message,"text/plain");
            }
            return Content("Silme işlemi başarılı", "text/plain");

        }

        public ActionResult Index2(int id)
        {
            var kitap = ApiKitap.KitapGetir(id);
            if (kitap == null)
            {
                kitap = new Kitap();
            }

            var yazarListesi = ApiYazar.YazarListe();
            var kategoriListesi = ApiKategori.KategoriListe();

            ViewBag.YazarListesi = yazarListesi;
            ViewBag.KategoriListesi = kategoriListesi;


            return View(kitap);
        }


        [HttpPost]
        public async Task<ActionResult> Add(Kitap kitap)
        {
            var success = await ApiKitap.KitapEkle(kitap);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Kitap kitap)
        {
            var success = await ApiKitap.KitapDuzenle(id, kitap);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

    }
}
