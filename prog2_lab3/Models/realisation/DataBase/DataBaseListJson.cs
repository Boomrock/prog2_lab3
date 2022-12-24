/*using Newtonsoft.Json;
using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace prog2_lab3.Models.realisation.DataBase
{
    class DataBaseListJson<TypeIList, TypeObject> : IDataBaseList<TypeIList, TypeObject> where TypeIList : IList<TypeObject>
    {
        string path;
        Dictionary<string, TypeIList> Dictinary;
        public bool Connect(string path)
        {
            this.path = path;
            Dictinary = JsonConvert.DeserializeObject<Dictionary<string, TypeIList>>(File.ReadAllText(path));
            if (Dictinary == null)
            {
                Dictinary = new Dictionary<string, TypeIList>();
                return false;
            }
            return true;
        }
        private bool Connect()
        {

            Dictinary = JsonConvert.DeserializeObject<Dictionary<string, TypeIList>>(File.ReadAllText(path));
            if (Dictinary == null)
            {
                Dictinary = new Dictionary<string, TypeIList>();
                return false;
            }
            return true;
        }

        public TypeIList Get(string nameObject)
        {
            Connect();
            if (Dictinary.ContainsKey(nameObject))
                return Dictinary[nameObject];
            else
                return default;
        }

        public void Set(string nameObject, TypeIList value)
        {
            if (Dictinary.ContainsKey(nameObject))
                Dictinary[nameObject] = value;
            else
                Dictinary.Add(nameObject, value);
        }
        public void AddTo(string nameObject, TypeObject value)
        {
            if (Dictinary.ContainsKey(nameObject))
            {
                int index = Dictinary[nameObject].FindIndex(t => nameof(t) == nameObject);
                if (index != -1)
                {
                    Dictinary[type][index] = value;
                    return value;
                }

                Dictinary[type].Add(value);
                return value;
            }
            Dictinary.Add(type, new List<object>() { value });
            return value;
        }
    }
}
*/