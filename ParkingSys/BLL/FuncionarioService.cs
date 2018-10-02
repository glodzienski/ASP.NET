using DAL;
using Data.ParkingSys.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class FuncionarioService : IBaseService<Funcionario>
    {
        static readonly FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

        public void Create(Funcionario model)
        {
            funcionarioDAO.Create(model);
        }

        public void Destroy(Funcionario model)
        {
            funcionarioDAO.Destroy(model);
        }

        public List<Funcionario> List()
        {
            return funcionarioDAO.List();
        }

        public Funcionario Show(int id)
        {
            return funcionarioDAO.Show(id);
        }

        public void Update(Funcionario model)
        {
            funcionarioDAO.Update(model);
        }

        public Funcionario GetByEmail(string email)
        {
            return funcionarioDAO.GetByEmail(email);
        }
    }
}
