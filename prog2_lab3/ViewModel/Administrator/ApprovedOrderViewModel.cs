using prog2_lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class ApprovedOrderViewModel:ViewModel
    {
        Action<Order> NotifyChangeStatus;
        public ObservableCollection<Order> ApprovedOrders { get; set; }
        public ApprovedOrderViewModel(IEnumerable<Order> ApprovedOrders, ref Action<Order> NotifyChangeStatus)
        {
            if (ApprovedOrders != null)
                this.ApprovedOrders = new ObservableCollection<Order>(ApprovedOrders);
            else
                this.ApprovedOrders = new ObservableCollection<Order>();

            NotifyChangeStatus += AddElement;
            

            // eventHendler.Invoke(new Order(2, Сategories.SecondCatigory, new Models.realisation.Owner("neJan", "cherezov", "andreevich", 2, "rqt", "123"), true));
        }



        void AddElement(Order order)
        {
            ApprovedOrders.Add(order);
        }


    }
}
