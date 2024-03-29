﻿using Newtonsoft.Json;
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
        Owner owner;
        public bool status { get; set; }
        public int Id { get => id; set => id = value; }
        [JsonIgnore]
        public string Status { get => status ? "Одобрено" : "Не одобрено"; }
        public Categories Сategory { get => сategory; set => сategory = value; }

        public Owner Owner { get => owner; set => owner = value; }
        public string NameOwmer { get => Owner.Name + " " + Owner.LastName + " " + Owner.Patronymic; }
        public Order(int id, Categories сategory, Owner owner, bool status)
        {
            this.id = id;
            this.сategory = сategory;
            this.owner = owner;
            this.status = status;
        }
    }
}
