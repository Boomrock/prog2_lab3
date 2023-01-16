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
    class MakeOrderViewModel : ViewModel, prog2_lab3.Models.Abstract.Observer.IObserver<Order>
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
        public RelayCommand MakeOrderCommand { get; set; }
        prog2_lab3.Models.Abstract.Observer.IObservable<Order> observable;
        public MakeOrderViewModel(IDataBase<object> dataBase, User owner, prog2_lab3.Models.Abstract.Observer.IObservable<Order> observable)
        {
            this.observable = observable;
            this.owner = owner;
            this.dataBase = dataBase;
            ProductNames = new List<string>();
            TransportsString = new ObservableCollection<string>();
            Transports = (List<Transport>)dataBase.Get("Transport");
            Products = (List<Product>)dataBase.Get("Products");
            Cities = (List<string>)dataBase.Get("Cities");
            Products.ForEach(s => ProductNames.Add(s.Name));
            MakeOrderCommand = new RelayCommand(makeOrder);


        }
        void makeOrder()
        {


            int lastIdOrder = (int)dataBase.Get("LastIdOrder");
            var product         = Products.Find(s => s.Name == SelectedProduct);
            var transport       = Transports.Find(s => s.Name == SelectedTransport);
            float TotalPrice    = product.Price + product.Weight * 0.5f + transport.Cost;
            Order order = new Order(lastIdOrder++, product, owner,false, transport, TotalPrice);

            var OrdersForAproval = (List<Order>)dataBase.Get("OrdersForApproval");
            if(OrdersForAproval == null)
            {
                OrdersForAproval = new List<Order>(); 
            }
            OrdersForAproval.Add(order);
            observable.NotifyObservers(order);
            dataBase.Set("LastIdOrder", lastIdOrder);
            dataBase.Set("OrdersForApproval", OrdersForAproval);

        }

        public void Update(Order data)
        {
            
        }
    }
}
