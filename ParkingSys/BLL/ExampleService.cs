using System.Collections.Generic;
using DAL;
using Data.ParkingSys.Model;

namespace BLL
{
    public class ExampleService : IBaseService<Model>
    {
        static readonly ExampleDAO exampleDAO = new ExampleDAO();

        public void Create(Model model)
        {
            throw new System.NotImplementedException();
        }

        public void Destroy(Model model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model> List()
        {
            throw new System.NotImplementedException();
        }

        public Model Show(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Model model)
        {
            throw new System.NotImplementedException();
        }
    }
}
