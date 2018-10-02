using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Teste.Controllers
{
    public class VeiculoMarcaController : ApiController
    {
        static readonly VeiculoService service = new VeiculoService();
        // GET api/values
        public HttpResponseMessage Get()
        {
            List<VeiculoMarcaDTO> marcas = service.ListVeiculoMarcas();
            return Request.CreateResponse(HttpStatusCode.OK, marcas);
        }
    }
}
