using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BLL
{
    public class ViaCepService
    {
        public ViaCepDTO GetCep(string cep)
        {
            WebApiClient client = new WebApiClient("https://viacep.com.br");
            string s = String.Format("ws/{0:00000000}/json", cep);
            return client.GetJson<ViaCepDTO>(s);
        }
    }
}
