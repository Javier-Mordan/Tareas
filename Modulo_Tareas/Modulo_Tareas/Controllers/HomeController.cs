using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modulo_Tareas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult VerificarLogin(string uname, string psw)
        {
            if (uname == null)
            {
                return View();
            }
            return RedirectToAction("Contact");
        }

        public bool Verificar_Usuario(string uname = "", string psw = "", string psw2 = "", int user = 0)
        {
            if (psw == psw2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}