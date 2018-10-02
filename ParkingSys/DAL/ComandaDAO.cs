using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ComandaDAO : IBaseDAO<Comanda>
    {
        public void Create(Comanda model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Comanda.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Comanda model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Comanda> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                var comanda = db.Comanda
                    .Include(c => c._Cliente)
                    .Include(c => c._ComandaStatus)
                    .Include(c => c._Funcionario)
                    .Include(c => c._Servico)
                    .Include(c => c._Vaga)
                    .Include(c => c._Veiculo);
                return comanda.ToList();
            }
        }

        public Comanda Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Comanda.Where(model => model.ComandaID == id)
                    .Include(model => model._Cliente)
                    .Include(model => model._ComandaStatus)
                    .Include(model => model._Funcionario)
                    .Include(model => model._Servico)
                    .Include(model => model._Vaga)
                    .Include(model => model._Veiculo)
                    .FirstOrDefault();
            }
        }

        public Comanda ShortShow(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Comanda.Where(model => model.ComandaID == id).FirstOrDefault();
            }
        }

        public void Update(Comanda model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
