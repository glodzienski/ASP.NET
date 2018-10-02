using System.Web.Mvc;
using BLL;
using Data.ParkingSys.Model;

namespace Teste.Controllers
{
    public class ClienteController : BaseController
    {
        static readonly ClienteService service = new ClienteService();

        public ActionResult Index()
        {
            if (!base.VerifyIsAuthenticated()) {return base.RedirectHome();}            
            return View(service.List());
        }

        public ActionResult Details(int id)
        {
            if (!base.VerifyIsAuthenticated()) { return base.RedirectHome(); }
            Cliente cliente = service.Show(id);
            return PartialView("ModalDetailsClienteView", cliente);
        }

        public ActionResult Create()
        {
            if (!base.VerifyIsAuthenticated()) { return base.RedirectHome(); }
            return PartialView("ModalCadastroClienteView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Sobrenome,Email,Ativo,Cpf,Cep,Numero,Uf,Cidade,Bairro,Logradouro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.Create(cliente);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        public ActionResult Edit(int id)
        {
            if (!base.VerifyIsAuthenticated()) { return base.RedirectHome(); }
            Cliente cliente = service.Show(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView("ModalCadastroClienteView", cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nome,Sobrenome,Email,Ativo,Cpf,Cep,Numero,Uf,Cidade,Bairro,Logradouro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.Update(cliente);
                return Json(new { Status = "OK" });
            }
            return Json(base.ErrorsToJson());
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Cliente cliente = service.Show(id);
            service.Destroy(cliente);
            return Json(new { Status = "OK" });
        }
    }
}
