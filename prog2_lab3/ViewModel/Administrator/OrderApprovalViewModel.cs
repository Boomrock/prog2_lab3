using prog2_lab3.Command;
using prog2_lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class OrderApprovalViewModel : ViewModel
    {
        private ObservableCollection<Order> ordersForAproval;
        private Action<Order> NotifyChangeStatus;

        #region public 
        private Order selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        public RelayCommand<Order> AprovalCommand { get; set; }

        public ObservableCollection<Order> OrdersForAproval { get => ordersForAproval; set => ordersForAproval = value; }
        #endregion 


        public OrderApprovalViewModel(IEnumerable<Order> Orders, ref Action<Order> NotifyChangeStatus)
        {
            OrdersForAproval = new ObservableCollection<Order>(Orders);
            AprovalCommand = new RelayCommand<Order>(ArovalOrder);
            this.NotifyChangeStatus = NotifyChangeStatus;
        }
        private void ArovalOrder(Order order)
        {
            
            OrdersForAproval.Remove(order);
            order.status = true;
            NotifyChangeStatus?.Invoke(order);
        }
    }
}
