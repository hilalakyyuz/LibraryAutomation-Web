using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            var yazarlar = ApiYazar.YazarListe();
            return View(yazarlar);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var success = await ApiYazar.YazarSil(id);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Index2(int id)
        {
            var yazar = ApiYazar.YazarGetir(id);
            if (yazar == null)
            {
                yazar = new Yazar();
            }

            return View(yazar);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Yazar yazar)
        {
            var success = await ApiYazar.YazarEkle(yazar);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<ActionResult> Edit(int id, Yazar yazar)
        {
            var success = await ApiYazar.YazarDuzenle(id, yazar);

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
