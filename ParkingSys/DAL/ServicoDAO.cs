using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ServicoDAO : IBaseDAO<Servico>
    {
        public void Create(Servico model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Servico.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Servico model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Servico> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Servico.ToList();
            }
        }

        public Servico Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Servico.Find(id);
            }
        }

        public void Update(Servico model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
