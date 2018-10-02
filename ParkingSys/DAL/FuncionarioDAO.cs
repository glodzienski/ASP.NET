using Data.ParkingSys.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class FuncionarioDAO : IBaseDAO<Funcionario>
    {
        public void Create(Funcionario model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Funcionario.Add(model);
                db.SaveChanges();
            }
        }

        public void Destroy(Funcionario model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Funcionario> List()
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Funcionario.ToList();
            }
        }

        public Funcionario Show(int id)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Funcionario.Find(id);
            }
        }

        public void Update(Funcionario model)
        {
            using (var db = new ParkingSystemDBContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Funcionario GetByEmail(string email)
        {
            using (var db = new ParkingSystemDBContext())
            {
                return db.Funcionario
                    .Where(model => model.Email == email)
                    .FirstOrDefault();
            }
        }
    }
}
