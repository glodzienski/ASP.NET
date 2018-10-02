using DAL;
using Data.ParkingSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestes
{
    class Program
    {
        static readonly VagaDAO vagaDAO = new VagaDAO();

        static void Main(string[] args)
        {
            List<Vaga> vaga = vagaDAO.List();
        }
    }
}
