using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.realisation
{
    class User
    {
        public int Id;
        public string Password;
        public string Login;
        public string Name;
        public string LastName;
        public string Patronymic;
        public Rights Right;
        public User()
        {

        }
        public User(string Name, string LastName, string Patronymic)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Patronymic = Patronymic;
        }
        public User(int Id, string Password, string Login, string Name, string LastName, string Patronymic, Rights Right) :this( Name, LastName, Patronymic)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Patronymic = Patronymic;
            this.Id = Id;
            this.Password = Password;
            this.Login = Login;
            this.Right = Right;
        }
        // public abstract void Initialization();
    }
}
