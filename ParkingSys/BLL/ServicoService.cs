using DAL;
using Data.ParkingSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicoService : IBaseService<Servico>
    {
        static readonly ServicoDAO servicoDAO = new ServicoDAO();
        public void Create(Servico model)
        {
            servicoDAO.Create(model);
        }

        public void Destroy(Servico model)
        {
            servicoDAO.Destroy(model);
        }

        public List<Servico> List()
        {
            return servicoDAO.List();
        }

        public Servico Show(int id)
        {
            return servicoDAO.Show(id);
        }

        public void Update(Servico model)
        {
            servicoDAO.Update(model);
        }
    }
}
