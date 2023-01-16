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
        Dictionary<string, object> dictionary;
        Dictionary<string, Type> types;

        public DataBaseJsone(string path)
        {
            if (!File.Exists(path))
                return;
            this.path = path;
            dictionary = new Dictionary<string, object>();

            //путь к файлу с типами данных
            this.pathType = Path.GetDirectoryName(path) + @"\\" + Path.GetFileNameWithoutExtension(path) + "Type.txt";
            Connect();
        }    
        private bool Connect()
        {
            //открываем файл
            var jsonFile = File.ReadAllText(path);

            //Десерелизуем в Словарь в котором у нас назавние переменной и текст с ее json содежржанием
            var tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);

            //открываем и десерелизуем файл в котором хранятся привезки типы данных к переменным
            types = JsonConvert.DeserializeObject<Dictionary<string, Type>>(File.ReadAllText(pathType));


            if (types == null)
                types = new Dictionary<string, Type>();
            if (tempDictionary == null)
                return false;


           
            // открываем файл

            //связываем в один Словарь название перемменных их данные и тип 
            foreach (var key in tempDictionary.Keys)
            {
                if (!dictionary.ContainsKey(key))
                {
                    var type = types[key];

                    dictionary.Add(key, JsonConvert.DeserializeObject(tempDictionary[key], type));
                }

            }
            return true;
        }
      /*  public bool Connect(string path)
        {
            if (!File.Exists(path))
                return false;
            this.path = path;

            //путь к файлу с типами данных
            this.pathType = Path.GetDirectoryName(path) +@"\\"+ Path.GetFileNameWithoutExtension(path) + "Type.txt";

            return Connect();
        }*/

        public object Get(string nameObject)
        {
            Connect();
            
            if (dictionary.ContainsKey(nameObject))
            {
                
                return dictionary[nameObject];
            }
                
            else
                return default;

        }

        public void Set(string nameObject, object value)
        {

            if (dictionary.ContainsKey(nameObject))
            {
                dictionary[nameObject] = value;
                save();
            }
            else
            {
                dictionary.Add(nameObject, value);
                if (!types.ContainsKey(nameObject))
                    types.Add(nameObject, value.GetType());
                save();
            }
        }
        private bool save()
        {

            var tempstr = new Dictionary<string, string>();

            foreach (var key in dictionary.Keys)
            {
                tempstr.Add(key, JsonConvert.SerializeObject(dictionary[key]));
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
