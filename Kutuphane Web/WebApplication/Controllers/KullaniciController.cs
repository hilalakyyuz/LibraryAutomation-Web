using Microsoft.AspNetCore.Http;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 3;

            var kullanicilar = ApiKullanici.KullaniciListe().ToPagedList(pageNumber, pageSize);
            return View(kullanicilar);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var success = await ApiKullanici.KullaniciSil(id);

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
            var kullanici = ApiKullanici.KullaniciGetir(id);
            //var resTask = ApiResim.GetVarsayilanResim(id);
            if (kullanici == null)
            {
                kullanici = new Kullanici();
            }
            //var res = await resTask;

            //if (res != null && res.Resim.Length > 0)
            //{
            //    ViewBag.UserImageBase64 = Convert.ToBase64String(kullanici.Resim);
            //}
            //else
            //{

            //}
            return View(kullanici);
        }
        [HttpPost]
        public async Task<ActionResult> Add(Kullanici kullanici, HttpPostedFileBase uploadfile)
        {
            if (uploadfile != null && uploadfile.ContentLength > 0)
            {
                byte[] fileBytes = new byte[uploadfile.ContentLength];
                uploadfile.InputStream.Read(fileBytes, 0, uploadfile.ContentLength);
                kullanici.Resim = fileBytes;
            }

            var success = await ApiKullanici.KullaniciEkle(kullanici);
         
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<ActionResult> Edit(int id, Kullanici kullanici, HttpPostedFileBase uploadfile)
        {
            if (uploadfile != null && uploadfile.ContentLength > 0)
            {
                byte[] fileBytes = new byte[uploadfile.ContentLength];
                uploadfile.InputStream.Read(fileBytes, 0, uploadfile.ContentLength);
                kullanici.Resim = fileBytes;
            }
            var success = await ApiKullanici.KullaniciDuzenle(id, kullanici);
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