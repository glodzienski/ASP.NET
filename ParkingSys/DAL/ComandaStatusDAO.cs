using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ComandaStatusDAO : IBaseDAO<ComandaStatus>
    {
        public void Create(ComandaStatus model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.ComandaStatus.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(ComandaStatus model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ComandaStatus> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.ComandaStatus.ToList();
            }
        }

        public ComandaStatus Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.ComandaStatus.Find(id);
            }
        }

        public void Update(ComandaStatus model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
