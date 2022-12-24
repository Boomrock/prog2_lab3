using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.ViewModel.UserView
{
    class MakeOrderViewModel:ViewModel
    {
        internal Owner user; 
        public string SelectedCategory { get; set; }
        public string SelectedCity { get; set; }
        public string SelectedTransport { get; set; }
        public RelayCommand<Order> SendOrder { get; set; }
        public string[] Category { get; set; }
        public List<string> Citys { get; set; }
        public List<string> Transports { get; set; }
        public MakeOrderViewModel(User user)
        {
            Category = Enum.GetNames(typeof(Categories));
            this.user = (Owner)user;
        }
        private bool sendOrder(string SelectedCategory, string SelectedCity,string SelectedTransport, IDataBase<List<Order>> dataBase, string NameListOrder)
        {
            
            for (int i = 0; i < Enum.GetValues(typeof(Categories)).Length; i++)
            {

            }
            var list = dataBase.Get(NameListOrder);
            list.Add(new Order(list[list.Count - 1].Id + 1, new Owner(,user.id) ));
            dataBase.Set(NameListOrder, list);
            return 
        }



    }
}
