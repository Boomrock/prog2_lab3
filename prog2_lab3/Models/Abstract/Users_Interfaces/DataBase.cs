using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.Models.Abstract.Users_Interfaces
{
    interface DataBase
    {
        /// <summary>
        /// connect to DataBase
        /// </summary>
        void Connect();
        byte[] Get(int element);
        void Set(int element, byte[] data);
    }
}
