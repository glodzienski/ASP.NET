using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class VagaDAO : IBaseDAO<Vaga>
    {
        public void Create(Vaga model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Vaga.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Vaga model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Vaga> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                var vaga = db.Vaga.Include(v => v._VagaTipo);
                return vaga.ToList();
            }
        }

        public Vaga Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Vaga.Where(model => model.VagaID == id)
                    .Include(model => model._VagaTipo)
                    .FirstOrDefault();
            }
        }

        public void Update(Vaga model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
