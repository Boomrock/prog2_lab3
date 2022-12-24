using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    abstract class User
    {
        public int id;
        public string password;
        public string login;
        public User()
        {

        }
        public User(int id)
        {
            this.id = id;
        }

        public User(int id, string password, string login)
        {
            this.id = id;
            this.password = password;
            this.login = login;
        }
        // public abstract void Initialization();
    }
}
