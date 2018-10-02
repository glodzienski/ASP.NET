using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class VeiculoTipoDAO : IBaseDAO<VeiculoTipo>
    {
        public void Create(VeiculoTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.VeiculoTipo.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(VeiculoTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<VeiculoTipo> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.VeiculoTipo.ToList();
            }
        }

        public VeiculoTipo Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.VeiculoTipo.Find(id);
            }
        }

        public void Update(VeiculoTipo model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
