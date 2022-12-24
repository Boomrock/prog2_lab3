using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class OrderApprovalViewModel : ViewModel
    {
        private ObservableCollection<Order> ordersForAproval;
        private Action<Order> NotifyChangeApproved;
        private IDataBase<List<Order>> dataBase;
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


        public OrderApprovalViewModel(IDataBase<List<Order>> dataBase, ref Action<Order> NotifyChangeApproved )
        {
            this.dataBase = dataBase;
            this.NotifyChangeApproved = NotifyChangeApproved;
            OrdersForAproval = new ObservableCollection<Order>();
            try
            {
                OrdersForAproval = new ObservableCollection<Order>(dataBase.Get(nameof(OrdersForAproval)));
            }
            catch (Exception)
            {
            }
          
            AprovalCommand = new RelayCommand<Order>(ArovalOrder);
        }
        private void ArovalOrder(Order order)
        {
            
            OrdersForAproval.Remove(order);
            order.status = true;
            NotifyChangeApproved?.Invoke(order);
            dataBase.Set(nameof(OrdersForAproval), (List<Order>)OrdersForAproval.GetEnumerator());
        }
    }
}
