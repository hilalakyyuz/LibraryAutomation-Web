using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class OduncController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            var oduncler = ApiOdunc.OduncListe();
            return View(oduncler);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var success = await ApiOdunc.OduncSil(id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<ActionResult> Index2(int id)
        {
            var odunc = ApiOdunc.OduncGetir(id);
            if (odunc == null)
            {
                odunc = new Odunc();
            }
            var kitapListesi = ApiKitap.KitapListe();
            var kullaniciListesi = ApiKullanici.KullaniciListe();

            ViewBag.KitapListesi = kitapListesi;
            ViewBag.KullaniciListesi =kullaniciListesi;
            return View(odunc);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Odunc odunc)
        {
            var success = await ApiOdunc.OduncEkle(odunc);
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<ActionResult> Edit(int id,Odunc odunc)
        {
            var success = await ApiOdunc.OduncDuzenle(id, odunc);
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