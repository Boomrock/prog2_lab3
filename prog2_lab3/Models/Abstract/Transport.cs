using System.Collections.Generic;

namespace prog2_lab3.Models.Abstract
{
    class Transport
    {
        public Transport(string name, float cost, List<string> path, List<string> validCategory, List<Cargo> cargo)
        {
            Name = name;
            Cost = cost;
            Path = path;
            ValidCategory = validCategory;
            Cargo = cargo;
        }

        public string Name;
        public float Cost;
        public List<string> Path;
        public List<string> ValidCategory;
        public List<Cargo> Cargo;
    }
}
