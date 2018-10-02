using DAL;
using Data.ParkingSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VagaService : IBaseService<Vaga>
    {
        static readonly VagaDAO vagaDAO = new VagaDAO();
        static readonly VagaTipoDAO vagaTipoDAO = new VagaTipoDAO();

        public void Create(Vaga model)
        {
            vagaDAO.Create(model);
        }

        public void Destroy(Vaga model)
        {
            vagaDAO.Destroy(model);
        }

        public List<Vaga> List()
        {
            return vagaDAO.List();
        }

        public Vaga Show(int id)
        {
            Vaga vaga = vagaDAO.Show(id);
            return vaga;
        }

        public void Update(Vaga model)
        {
            vagaDAO.Update(model);
        }

        public List<VagaTipo> ListVagaTipos()
        {
            return vagaTipoDAO.List();
        }

    }
}
