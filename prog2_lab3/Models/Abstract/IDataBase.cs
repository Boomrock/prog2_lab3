using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    interface IDataBase<T>
    {
        public bool Connect(string path);
        public T Get(string nameObject);
        public void Set(string nameObject, T value);
    }
    interface IDataBaseList<TypeIList, TypeObject > where TypeIList: IList<TypeObject>
    {
        public bool Connect(string path);
        public TypeIList Get(string nameObject);
        public void Set(string nameObject, TypeIList value);
        public void AddTo(string nameObject, TypeObject value);
    }
}
