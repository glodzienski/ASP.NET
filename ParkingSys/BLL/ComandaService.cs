using DAL;
using Data.ParkingSys.Model;
using Enum;
using System.Collections.Generic;

namespace BLL
{
    public class ComandaService : IBaseService<Comanda>
    {
        static readonly ComandaDAO comandaDAO = new ComandaDAO();
        static readonly ServicoService servicoService = new ServicoService();

        public void Create(Comanda model)
        {
            model.ComandaStatusID = (int)ComandaStatusEnum.Ativa;
            model._ComandaStatus = null;
            model.Total = servicoService.Show(model.ServicoID).Valor;
            comandaDAO.Create(model);
        }

        public void Destroy(Comanda model)
        {
            comandaDAO.Destroy(model);
        }

        public List<Comanda> List()
        {
            return comandaDAO.List();
        }

        public Comanda Show(int id)
        {
            Comanda comanda = comandaDAO.Show(id);
            return comanda;
        }

        public Comanda ShortShow(int id)
        {
            Comanda comanda = comandaDAO.ShortShow(id);
            return comanda;
        }

        public void Update(Comanda model)
        {
            comandaDAO.Update(model);
        }

        public void Close(Comanda comanda)
        {
            comanda.ComandaStatusID = (int)ComandaStatusEnum.Fechada;
            Update(comanda);
        }
    }
}
