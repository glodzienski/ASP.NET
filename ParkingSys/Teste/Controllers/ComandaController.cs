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
    public class ComandaController : BaseController
    {
        static readonly ComandaService comandaService = new ComandaService();
        static readonly VeiculoService veiculoService = new VeiculoService();
        static readonly ClienteService clienteService = new ClienteService();
        static readonly VagaService vagaService = new VagaService();
        static readonly ServicoService servicoService = new ServicoService();

        private SelectList veiculos = new SelectList(veiculoService.List(), "VeiculoID", "Placa", 0);
        private SelectList clientes = new SelectList(clienteService.List(), "ClienteID", "Cpf", 0);
        private SelectList vagas = new SelectList(vagaService.List(), "VagaID", "Codigo", 0);
        private SelectList servicos = new SelectList(servicoService.List(), "ServicoID", "Nome", 0);

        // GET: Comanda
        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}
            return View(comandaService.List());
        }

        // GET: Comanda/Details/5
        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}
            Comanda comanda = comandaService.Show(id);
            return PartialView("ModalDetailsComandaView", comanda);
        }

        // GET: Comanda/Create
        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}
            ViewBag.clientes = clientes;
            ViewBag.servicos = servicos;
            ViewBag.vagas = vagas;
            ViewBag.veiculos = veiculos;
            return PartialView("ModalCadastroComandaView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoID,VagaID,ClienteID,FuncionarioID,VeiculoID")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                comanda.FuncionarioID = System.Convert.ToInt32(Session["FuncionarioID"]);
                comandaService.Create(comanda);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        // GET: Comanda/Edit/5
        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}
            Comanda comanda = comandaService.Show(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientes = new SelectList(clienteService.List(), "ClienteID", "Cpf", comanda.ClienteID);
            ViewBag.servicos = new SelectList(servicoService.List(), "ServicoID", "Nome", comanda.ServicoID);
            ViewBag.vagas = new SelectList(vagaService.List(), "VagaID", "Codigo", comanda.VagaID);
            ViewBag.veiculos =  new SelectList(veiculoService.List(), "VeiculoID", "Placa", comanda.VeiculoID);
            return PartialView("ModalCadastroComandaView", comanda);
        }

        // POST: Comanda/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComandaID,ServicoID,VagaID,ClienteID,VeiculoID")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                Comanda comandaToUpdate = comandaService.ShortShow(comanda.ComandaID);
                comandaToUpdate.ServicoID = comanda.ServicoID;
                comandaToUpdate.VagaID = comanda.VagaID;
                comandaToUpdate.ClienteID = comanda.ClienteID;
                comandaToUpdate.VeiculoID = comanda.VeiculoID;
                comandaService.Update(comandaToUpdate);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        public ActionResult Close(int id)
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}
            Comanda comanda = comandaService.ShortShow(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            comandaService.Close(comanda);
            return Json(new { Status = "OK" });
        }
    }
}
