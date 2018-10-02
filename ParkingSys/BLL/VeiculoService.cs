using DAL;
using Data.ParkingSys.Model;
using DTO;
using System.Collections.Generic;
using Utils;

namespace BLL
{
    public class VeiculoService : IBaseService<Veiculo>
    {
        static readonly VeiculoDAO veiculoDAO = new VeiculoDAO();
        static readonly VeiculoTipoDAO veiculoTipoDAO = new VeiculoTipoDAO();

        public void Create(Veiculo model)
        {
            veiculoDAO.Create(model);
        }

        public void Destroy(Veiculo model)
        {
            veiculoDAO.Destroy(model);
        }

        public List<Veiculo> List()
        {
            return veiculoDAO.List();
        }

        public Veiculo Show(int id)
        {
            Veiculo veiculo = veiculoDAO.Show(id);
            veiculo._VeiculoTipo = veiculoTipoDAO.Show(veiculo.VeiculoTipoID);
            return veiculo;
        }

        public void Update(Veiculo model)
        {
            veiculoDAO.Update(model);
        }

        public List<VeiculoTipo> ListVeiculoTipos()
        {
            return veiculoTipoDAO.List();
        }

        public List<VeiculoMarcaDTO> ListVeiculoMarcas()
        {
            WebApiClient client = new WebApiClient("http://fipeapi.appspot.com");
            // http://fipeapi.appspot.com/ws/00000000/json
            List<VeiculoMarcaDTO> viaCep = client.GetJson<List<VeiculoMarcaDTO>>("/api/1/carros/marcas.json");
            return viaCep;
        }
    }
}
