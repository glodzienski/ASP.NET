using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class VeiculoDAO : IBaseDAO<Veiculo>
    {
        public void Create(Veiculo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Veiculo.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Veiculo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Veiculo> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Veiculo
                    .Include(veiculo => veiculo._VeiculoTipo)
                    .Include(veiculo => veiculo._Cliente)
                    .ToList();
            }
        }

        public Veiculo Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Veiculo.Where(model => model.VeiculoID == id)
                    .Include(model => model._VeiculoTipo)
                    .Include(model => model._Cliente)
                    .FirstOrDefault();
            }
        }

        public void Update(Veiculo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
