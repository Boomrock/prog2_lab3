using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Text.Json;

namespace prog2_lab3.Models.realisation.DataBase
{
    class DataBaseJsone: IDataBase<object>
    {
        string path;
        Dictionary<string, object> dictinary;
        Dictionary<string, Type> types;

        public Dictionary<string, object> Dictinary
        {
        
            get
            {

                return dictinary;
                
            }
            set
            {
                dictinary = value;
                save();
            }
        }
        private bool Connect()
        {
            JsonSerializer.Deserialize<object>(File.ReadAllText(path));
         /*   Dictinary = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(path));*/

            if (Dictinary == null)
            {
                Dictinary = new Dictionary<string, object>();
                return false;
            }
            return true;
        }
        public bool Connect(string path)
        {
            this.path = path;

            types = JsonConvert.DeserializeAnonymousType<Type>(Dictinary["Type"], types[""]);
            try
            {
                Dictinary = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(path));
                foreach (var key in Dictinary.Keys)
                {

                }
                
/*                foreach (var key in Dictinary.Keys)
                {
                    Dictinary[key] = JsonConvert ((JObject)Dictinary[key]).ToObject<object>();
                }*/
                if (Dictinary == null)
                {
                    Dictinary = new Dictionary<string, object>();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public object Get(string nameObject)
        {
            Connect();
            
            if (Dictinary.ContainsKey(nameObject))
            {
                
                return Dictinary[nameObject];
            }
                
            else
                return default;

        }

        public void Set(string nameObject, object value)
        {

            if (Dictinary.ContainsKey(nameObject))
                Dictinary[nameObject] = value;
            else
            {
                Dictinary.Add(nameObject, value);
                save();
            }
        }
        private bool save()
        {
            Dictinary["Type"] = types;
            string jsonFile = JsonConvert.SerializeObject(Dictinary, type: typeof(Dictionary<string, object>), settings: null);
            File.WriteAllText(path, jsonFile);
            return true;
        }
        /*  string path;
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
          private bool Connect()
          {
              Dictinary = JsonConvert.DeserializeObject<Dictionary<string, List<Object>>>(File.ReadAllText(path));
              if (Dictinary == null)
              {
                  Dictinary = new Dictionary<string, List<object>>();
                  return false;
              }
              return true;
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
              Connect();
              if (Dictinary.ContainsKey(type))
              {
                  return Dictinary[type].Find(t => nameof(t) == nameObject);
              }
              else
              {
                  return null;
              }
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

          }*/

    }
}
