using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace WebApplication.Controllers
{
    public class KategoriController : Controller
    {
        
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1; 
            int pageSize = 7; 

            var kategoriler = ApiKategori.KategoriListe().ToPagedList(pageNumber, pageSize);
            return View(kategoriler);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var success = await ApiKategori.KategoriSil(id);

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
            var kategori = ApiKategori.KategoriGetir(id);
            if(kategori==null)
            {
                kategori = new Kategori();
            }
           
            return View(kategori);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Kategori kategori)
        {
            var success = await ApiKategori.KategoriEkle(kategori);

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<ActionResult> Edit(int id, Kategori kategori)
        {
            var success = await ApiKategori.KategoriDuzenle(id,kategori);

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