using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using Data.ParkingSys.Model;

namespace Teste.Controllers
{
    public class FuncionarioController : BaseController
    {
        static readonly FuncionarioService service = new FuncionarioService();

        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return View(service.List());
        }

        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) { return base.RedirectHome(); }
            Funcionario funcionario = service.Show(id);
            return PartialView("ModalDetailsFuncionarioView", funcionario);
        }

        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return PartialView("ModalCadastroFuncionarioView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Sobrenome,Email,Senha,Ativo,Cpf,Administrador")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                service.Create(funcionario);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Funcionario funcionario = service.Show(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return PartialView("ModalCadastroFuncionarioView", funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuncionarioID,Nome,Sobrenome,Email,Senha,Ativo,Cpf,Administrador")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                service.Update(funcionario);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Funcionario funcionario = service.Show(id);
            service.Destroy(funcionario);
            return Json(new { Status = "OK" });
        }
    }
}
