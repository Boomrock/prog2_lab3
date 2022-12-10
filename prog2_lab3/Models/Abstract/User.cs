using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract
{
    abstract class User
    {
        internal int id;
        internal string password;
        internal string login;

        protected User(int id, string password, string login)
        {
            this.id = id;
            this.password = password;
            this.login = login;
        }
        // public abstract void Initialization();
    }
}
