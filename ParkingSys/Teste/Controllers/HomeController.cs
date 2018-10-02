using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["FuncionarioID"] == null)
            {
                ViewBag.ErroLogin = null;
                return RedirectToAction("Index", "Login");
            } else
            {
                return RedirectToAction("Index", "Comanda");
            }
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
}
