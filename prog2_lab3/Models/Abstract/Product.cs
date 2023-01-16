using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    class Product
    {
        public Product(int price, string name, string description, string category)
        {
            Price = price;
            Name = name;
            Description = description;
            Category = category;
        }

        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

    }
}
