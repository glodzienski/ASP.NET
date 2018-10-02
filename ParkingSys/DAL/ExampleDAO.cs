using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ExampleDAO : IBaseDAO<Veiculo>
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
                return db.Veiculo.ToList();
            }
        }

        public Veiculo Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Veiculo.Find(id);
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
