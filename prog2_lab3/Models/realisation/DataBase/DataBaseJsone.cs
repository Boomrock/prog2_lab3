using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace prog2_lab3.Models.realisation.DataBase
{
    class DataBaseJsone: IDataBase<object>
    {
        string path;
        string pathType;
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
            }
        }
        private bool Connect()
        {
            try
            {
                var jsonFile = File.ReadAllText(path);
                var tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);
                types = JsonConvert.DeserializeObject<Dictionary<string, Type>>(File.ReadAllText(pathType));
                if (types == null)
                    types = new Dictionary<string, Type>();
                if (tempDictionary == null)
                    return false;
                foreach (var key in tempDictionary.Keys)
                {
                    if (!Dictinary.ContainsKey(key))
                    {
                        var type = types[key];
                        Dictinary.Add(key, JsonConvert.DeserializeAnonymousType(tempDictionary[key], type));
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool Connect(string path)
        {
            this.path = path;
            this.pathType = Path.GetDirectoryName(path) +@"\\"+ Path.GetFileNameWithoutExtension(path) + "Type.txt";
            Dictinary = new Dictionary<string, object>();
           
                var jsonFile = File.ReadAllText(path);
                var tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);
                types = JsonConvert.DeserializeObject<Dictionary<string, Type>>(File.ReadAllText(pathType));
                if(types == null)
                    types = new Dictionary<string, Type>();
                if (tempDictionary == null)
                    return false;
                foreach (var key in tempDictionary.Keys)
                {
                    if (!Dictinary.ContainsKey(key))
                    {
                        var type = types[key];
                      
                            Dictinary.Add(key, JsonConvert.DeserializeObject(tempDictionary[key], type));
                        
                       
                        
                    }

                }
            
       /*     catch (Exception)
            {
                return false;
            }*/
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
                if (!types.ContainsKey(nameObject))
                    types.Add(nameObject, value.GetType());
                save();
            }
        }
        private bool save()
        {

            var tempstr = new Dictionary<string, string>();

            foreach (var key in Dictinary.Keys)
            {
                tempstr.Add(key, JsonConvert.SerializeObject(Dictinary[key]));
            }
            string jsonFile = JsonConvert.SerializeObject(tempstr);
            File.WriteAllText(path, jsonFile);
            jsonFile = JsonConvert.SerializeObject(types);
            File.WriteAllText(pathType, jsonFile);
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
