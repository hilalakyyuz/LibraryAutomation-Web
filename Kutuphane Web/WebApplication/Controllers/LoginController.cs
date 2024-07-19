using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Loginn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string username, string password)
        {
            Gorevli user = new Gorevli { AdSoyad = username, Sifre = password };
            string result = await ApiGorevli.LoginAsync(user);

            if (result == "Giriş başarılı.")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ResultMessage = result;
                return View();
            }
        }
    }
}