using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class VagaTipoDAO : IBaseDAO<VagaTipo>
    {
        public void Create(VagaTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.VagaTipo.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(VagaTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<VagaTipo> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.VagaTipo.ToList();
            }
        }

        public VagaTipo Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.VagaTipo.Find(id);
            }
        }

        public void Update(VagaTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
