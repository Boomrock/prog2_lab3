using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    interface IDataBase<T>
    {
        public T Get(string nameObject);
        public void Set(string nameObject, T value);
    }
}
