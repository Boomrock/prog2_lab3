using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.realisation
{
    class Owner : User
    {
        public string Name;
        public string LastName;
        public string Patronymic;
        public Owner(string Name, string LastName, string Patronymic, int id, string login, string password) : base( id,  password, login)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Patronymic = Patronymic;
        }
    }
}
