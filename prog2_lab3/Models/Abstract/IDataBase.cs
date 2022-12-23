using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    interface IDataBase
    {
        public bool Connect(string path);
        public object Get(string nameObject, string type);
        public object Set(string nameObject, string type, object value);
    }
}
