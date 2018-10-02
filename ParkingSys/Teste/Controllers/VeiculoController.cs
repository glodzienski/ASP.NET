using System.Web.Mvc;
using BLL;
using Data.ParkingSys.Model;

namespace Teste.Controllers
{
    public class VeiculoController : BaseController
    {
        static readonly VeiculoService veiculoService = new VeiculoService();
        static readonly ClienteService clienteService = new ClienteService();

        private SelectList veiculoTipos = new SelectList(veiculoService.ListVeiculoTipos(), "VeiculoTipoID", " Nome", 0);
        private SelectList clientes = new SelectList(clienteService.List(), "ClienteID", "Cpf", 0);

        // GET: Veiculo
        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return View(veiculoService.List());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Veiculo veiculo = veiculoService.Show(id);
            return PartialView("ModalDetailsVeiculoView", veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            ViewBag.clientes = clientes;
            ViewBag.veiculoTipos = veiculoTipos;
            return PartialView("ModalCadastroVeiculoView");
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Placa,ClienteID,VeiculoTipoID,Marca")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculoService.Create(veiculo);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Veiculo veiculo = veiculoService.Show(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientes = new SelectList(clienteService.List(), "ClienteID", "Cpf", veiculo.ClienteID);
            ViewBag.veiculoTipos = new SelectList(veiculoService.ListVeiculoTipos(), "VeiculoTipoID", " Nome", veiculo.VeiculoTipoID);
            return PartialView("ModalCadastroVeiculoView", veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeiculoID,Placa,ClienteID,VeiculoTipoID,Marca")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculoService.Update(veiculo);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        // DELETE: Veiculo/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = veiculoService.Show(id);
            veiculoService.Destroy(veiculo);
            return Json(new { Status = "OK" });
        }
    }
}
