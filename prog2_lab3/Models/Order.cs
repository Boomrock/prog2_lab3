using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models
{
    class Order
    {
        int id;
        Сategories сategory;
        Owner owner;
        bool status;
        public int Id { get => id; set => id = value; }
        public bool Status { get => status; set => status = value; }
        public Сategories Сategory { get => сategory; set => сategory = value; }
        internal Owner Owner { get => owner; set => owner = value; }
        public string NameOwmer { get => Owner.Name + " " + Owner.LastName + " " + Owner.Patronymic; }
        public Order(int id, Сategories сategory, Owner owner, bool status)
        {
            this.Id = id;
            this.Сategory = сategory;
            this.Owner = owner;
            this.Status = status;
        }

  
        

    }
}
