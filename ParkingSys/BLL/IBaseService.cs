﻿using System.Collections.Generic;

namespace BLL
{
    interface IBaseService<Model>
    {
        void Create(Model model);

        void Update(Model model);

        void Destroy(Model model);

        List<Model> List();

        Model Show(int id);
    }
}
