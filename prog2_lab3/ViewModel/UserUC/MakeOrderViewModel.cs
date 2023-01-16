using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace prog2_lab3.ViewModel.UserUC
{
    class MakeOrderViewModel : ViewModel
    {

        private User owner;
        private IDataBase<object> dataBase;
        private string selectedCity;
        public string SelectedCity
        {
            get
            {
                return selectedCity;
            }
            set
            {
                TransportsString.Clear();
                foreach (var item in Transports)
                {
                    if (item.Path.Contains(value) && item.ValidCategory.Contains(Products.Find(s => s.Name == SelectedProduct).Category))
                    {
                        TransportsString.Add(item.Name);
                    }
                      
                }
                selectedCity = value;

            }
        }
        public string SelectedProduct  { get; set; }
        public string SelectedTransport { get; set; }
        public List<string> ProductNames { get; set; }
        public ObservableCollection<string> TransportsString { get; set; }
        public List<Transport> Transports { get; set; }
        public RelayCommand SendOrder { get; set; }
        public List<Product> Products { get; set; }
        public List<string> Cities { get; set; }

        public MakeOrderViewModel(IDataBase<object> dataBase, User owner)
        {
            this.owner = owner;
            this.dataBase = dataBase;
            ProductNames = new List<string>();
            TransportsString = new ObservableCollection<string>();
            Transports = (List<Transport>)dataBase.Get("Transport");
            Products = (List<Product>)dataBase.Get("Products");
            Cities = (List<string>)dataBase.Get("Cities");
            Products.ForEach(s => ProductNames.Add(s.Name));
            SendOrder = new RelayCommand(sendOrder);

        }
/*        float makeOrder()
        {

            int lastIdOrder = (int)dataBase.Get("LastIdOrder");

            Order order = new Order(lastIdOrder, owner);

            dataBase.Set("LastIdOrder", lastIdOrder++);
            return ;

        }*/
        void sendOrder()
        {
            List<Order> orders = (List<Order>)dataBase.Get("OrdersForAproval");
            int lastIdOrder = (int)dataBase.Get("LastIdOrder");


        }



    }
}
