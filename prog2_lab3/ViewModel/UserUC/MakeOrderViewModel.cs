using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.ViewModel.UserUC
{
    class MakeOrderViewModel : ViewModel
    {
        private string selectedCity;
        private User owner;
        private IDataBase<object> dataBase;

        public string SelectedCategory { get; set; }
        public string SelectedCity { get => selectedCity; set => selectedCity = value; }
        public string SelectedTransport { get; set; }
        public RelayCommand SendOrder { get; set; }
        public string[] Category { get; set; }
        public string[] Cities { get; set; }
        public string[] Transports { get; set; }
        public MakeOrderViewModel(IDataBase<object> dataBase, User owner)
        {
            this.owner = owner;
            this.dataBase = dataBase;

            SendOrder = new RelayCommand(sendOrder);
            Category = (string[])dataBase.Get("Categories");
            Cities = (string[])dataBase.Get("Cities");
            Transports = (string[])dataBase.Get("Transports");

        }
        void sendOrder()
        {
            List<Order> orders = (List<Order>)dataBase.Get("OrdersForAproval");
            int lastIdOrder = (int)dataBase.Get("LastIdOrder");
/*
            Order order = new Order(lastIdOrder, )
            orders.Add(order);
            dataBaseOrders.Set("OrdersForAproval", orders);*/
        }



    }
}
