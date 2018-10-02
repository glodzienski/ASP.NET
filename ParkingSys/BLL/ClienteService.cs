using DAL;
using Data.ParkingSys.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ClienteService : IBaseService<Cliente>
    {
        static readonly ClienteDAO clienteDAO = new ClienteDAO();
        public void Create(Cliente model)
        {
            clienteDAO.Create(model);
        }

        public void Destroy(Cliente model)
        {
            clienteDAO.Destroy(model);
        }

        public List<Cliente> List()
        {
            return clienteDAO.List();
        }

        public Cliente Show(int id)
        {
            return clienteDAO.Show(id);
        }

        public void Update(Cliente model)
        {
            clienteDAO.Update(model);
        }
    }
}
