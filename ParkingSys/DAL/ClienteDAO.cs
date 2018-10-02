using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class ClienteDAO : IBaseDAO<Cliente>
    {
        public void Create(Cliente model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Cliente.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Cliente model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Cliente> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Cliente.ToList();
            }
        }

        public Cliente Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Cliente.Find(id);
            }
        }

        public void Update(Cliente model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
