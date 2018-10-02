using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using Data.ParkingSys.Model;

namespace Teste.Controllers
{
    public class VagaController : BaseController
    { 
        static readonly VagaService service = new VagaService();
        private SelectList vagaTipos = new SelectList(service.ListVagaTipos(), "VagaTipoID", "Descricao", 0);

        // GET: Vaga
        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return View(service.List());
        }

        // GET: Vaga/Details/5
        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Vaga vaga = service.Show(id);
            return PartialView("ModalDetailsVagaView", vaga);
        }

        // GET: Vaga/Create
        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            ViewBag.vagaTipos = vagaTipos;
            return PartialView("ModalCadastroVagaView");
        }

        // POST: Vaga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Andar,Ocupada,Ativo,VagaTipoID")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                service.Create(vaga);
                return Json(new { Status = "OK"});
            }
            return Json(base.ErrorsToJson());
        }

        // GET: Vaga/Edit/5
        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Vaga vaga = service.Show(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.vagaTipos = vagaTipos;
            return PartialView("ModalCadastroVagaView", vaga);
        }

        // POST: Vaga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VagaID,Codigo,Andar,Ocupada,Ativo,VagaTipoID")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                service.Update(vaga);
                return Json(new { Status = "OK"});
            }
            return Json(base.ErrorsToJson());
        }

        // POST: Vaga/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Vaga vaga = service.Show(id);
            service.Destroy(vaga);
            return Json(new { Status = "OK" });
        }
    }
}
