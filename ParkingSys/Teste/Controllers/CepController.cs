using BLL;
using DTO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Teste.Controllers
{
    public class CepController : ApiController
    {
        static readonly ViaCepService service = new ViaCepService();

        public HttpResponseMessage Get(string cep)
        {
            ViaCepDTO cepDTO = service.GetCep(cep);
            if (cepDTO.bairro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cepDTO);
        }
    }
}