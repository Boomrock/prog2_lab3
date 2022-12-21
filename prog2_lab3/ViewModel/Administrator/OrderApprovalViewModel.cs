using prog2_lab3.Command;
using prog2_lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class OrderApprovalViewModel: ViewModel
    {
        private ObservableCollection<Order> ordersForAproval;
        private Action<Order> NotifyChangeStatus;
        public RelayCommand<Order> AprovalCommand { get; set; }

        public ObservableCollection<Order> OrdersForAproval { get => ordersForAproval; set => ordersForAproval = value; }
        public OrderApprovalViewModel(IEnumerable<Order> Orders, ref Action<Order> NotifyChangeStatus)
        {
            OrdersForAproval = new ObservableCollection<Order>(Orders);
            this.NotifyChangeStatus = NotifyChangeStatus;
            Order order = new Order(2, Сategories.SecondCatigory, new Models.realisation.Owner("neJan", "cherezov", "andreevich", 2, "rqt", "123"), true);
            OrdersForAproval.Add(order);
            ArovalOrder(order);
            AprovalCommand =new RelayCommand<Order>(ArovalOrder);


        }
        void ArovalOrder( Order order)
        {
            if (order.status)
            {
                ordersForAproval.Remove(order);
                NotifyChangeStatus?.Invoke(order);
            }
        }
      

       
    }
}
