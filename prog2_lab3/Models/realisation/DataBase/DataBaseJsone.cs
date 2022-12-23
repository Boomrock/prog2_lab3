using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace prog2_lab3.Models.realisation.DataBase
{
    class DataBaseJsone : IDataBase
    {
        string path;
        Dictionary<string, List<Object>> dictinary;

        public Dictionary<string, List<object>> Dictinary
        {
            get
            {
                return dictinary;
            }
            set
            {
                dictinary = value;
                Save();
            }
        }

        public bool Connect(string path)
        {
            this.path = path;
            Dictinary = JsonConvert.DeserializeObject<Dictionary<string, List<Object>>>(File.ReadAllText(path));
            if (Dictinary == null)
            {
                Dictinary = new Dictionary<string, List<object>>();
                return false;
            }
            return true;
        }

        public object Get(string nameObject, string type)
        {
            return Dictinary[type].Find(t => nameof(t) == nameObject);
        }

        public object Set(string nameObject, string type, object value)
        {
            if (Dictinary.ContainsKey(type))
            {
                int index = Dictinary[type].FindIndex(t => nameof(t) == nameObject);
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
        private bool Save()
        {
            string jsonFile = JsonConvert.SerializeObject(Dictinary);
            File.WriteAllText(path, jsonFile);
            return true;

        }
    }
}
