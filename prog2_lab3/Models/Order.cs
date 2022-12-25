using Newtonsoft.Json;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models
{
    [Serializable]
    class Order
    {
        int id;
        Categories сategory;
        User owner;
        public bool status { get; set; }
        public int Id { get => id; set => id = value; }
        [JsonIgnore]
        public string Status { get => status ? "Одобрено" : "Не одобрено"; }
        public Categories Сategory { get => сategory; set => сategory = value; }

        public User User { get => owner; set => owner = value; }
        public string NameOwmer { get => User.Name + " " + User.LastName + " " + User.Patronymic; }
        public Order(int id, Categories сategory, User owner, bool status)
        {
            this.id = id;
            this.сategory = сategory;
            this.owner = owner;
            this.status = status;
        }
    }
}
