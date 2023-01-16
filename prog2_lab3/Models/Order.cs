using Newtonsoft.Json;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace prog2_lab3.Models
{
    [Serializable]
    class Order
    {
        int id;
        Product product;
        User owner;
        public bool status { get; set; }
        public int Id { get => id; set => id = value; }
        [JsonIgnore]
        public string Status { get => status ? "Одобрено" : "Не одобрено"; }
        public Product Product { get => product; set => product = value; }
        public Transport Transport { get; set; } 
        public float Price { get; set; }

        public User User { get => owner; set => owner = value; }
        public string NameOwmer { get => User.Name + " " + User.LastName + " " + User.Patronymic; }
        public Order(int id, Product product, User owner, bool status, Transport transport, float price)
        {
            this.id = id;
            this.product = product;
            this.owner = owner;
            this.status = status;
            this.Transport = transport;
            this.Price = price;
        }


        public Order() { }

    }
}
