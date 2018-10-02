using System.Web.Mvc;
using BLL;
using Data.ParkingSys.Model;

namespace Teste.Controllers
{
    public class ServicoController : BaseController
    {
        static readonly ServicoService service = new ServicoService();

        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return View(service.List());
        }

        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Servico servico = service.Show(id);
            return PartialView("ModalDetailsServicoView", servico);
        }

        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            return PartialView("ModalCadastroServicoView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Codigo,Ativo,Valor")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                service.Create(servico);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated() || !base.VerifyIsAdmin()) {return base.RedirectHome();}
            Servico servico = service.Show(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return PartialView("ModalCadastroServicoView", servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoID,Nome,Codigo,Ativo,Valor")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                service.Update(servico);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Servico servico = service.Show(id);
            service.Destroy(servico);
            return Json(new { Status = "OK" });
        }
    }
}
