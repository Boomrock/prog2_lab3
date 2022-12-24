using prog2_lab3.Command;
using prog2_lab3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.ViewModel.User
{
    class MakeOrderViewModel:ViewModel
    {

        public string SelectedCategory { get; set; }
        public string SelectedCity { get; set; }
        public string SelectedTransport { get; set; }
        public RelayCommand<Order> SendOrder { get; set; }
        public string[] Category { get; set; }
        public List<string> Citys { get; set; }
        public List<string> Transports { get; set; }
        public MakeOrderViewModel()
        {
            Category = Enum.GetNames(typeof(Categories)); 
        }



    }
}
