using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Teste.Controllers
{
    public class BaseController : Controller
    {
        public object ErrorsToJson()
        {
            List<object> errors = new List<object>();
            foreach (var item in ModelState)
            {
                OrderedDictionary errorJ = new OrderedDictionary();
                string errorsConcat = "";

                foreach (var error in item.Value.Errors)
                {
                    errorsConcat += error.ErrorMessage + " \n";
                }
                if (errorsConcat != "")
                {
                    errorJ.Add("field", item.Key);
                    errorJ.Add("message", errorsConcat);
                    errors.Add(errorJ);
                }
            }
            return errors;
        }

        public bool VerifyIsAuthenticated()
        {
            return Session["FuncionarioID"] != null;
        }

        public bool VerifyIsAdmin()
        {
            return (bool)Session["Administrador"];
        }

        public ActionResult RedirectHome()
        {
            return RedirectToAction("../Home/");
        }
    }
}