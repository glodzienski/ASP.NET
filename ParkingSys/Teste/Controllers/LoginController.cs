using BLL;
using Data.ParkingSys.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class LoginController : BaseController
    {
        static readonly FuncionarioService service = new FuncionarioService();

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Senha")] LoginDTO login)
        {
            Funcionario funcionario = service.GetByEmail(login.Email ?? "");
            if (funcionario == null)
            {
                ViewBag.ErroLogin = "Funcionário não existe na empresa.";
                return Index();
            }
            if (funcionario.Senha == login.Senha)
            {
                Session["FuncionarioID"] = funcionario.FuncionarioID;
                Session["Administrador"] = funcionario.Administrador;
                int a = System.Convert.ToInt32(Session["FuncionarioID"]);
                return RedirectToAction("../Comanda/");
            }
            ViewBag.ErroLogin = "Senha incorreta.";
            return Index();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["FuncionarioID"] = null;
            Session["Administrador"] = null;
            return RedirectToAction("../Home");
        }
    }
}