using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.Abstract.Observer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace prog2_lab3.ViewModel.Administrator
{
    class OrderApprovalViewModel : ViewModel, IObserver<Order>
    {
        private ObservableCollection<Order> ordersForAproval;
        private IDataBase<object> dataBase;
        private IObservable<Order> observable;
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


        public OrderApprovalViewModel(IDataBase<object> dataBase, IObservable<Order> observable)
        {
            this.dataBase = dataBase;
            this.observable = observable;
            observable.AddObserver(this);
            OrdersForAproval = new ObservableCollection<Order>();
            try
            {
                OrdersForAproval = new ObservableCollection<Order>((List<Order>)dataBase.Get("OrdersForAproval"));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n code: 416857454867787");
            }
            AprovalCommand = new RelayCommand<Order>(ArovalOrder);
        }
        private void ArovalOrder(Order order)
        { 
            if (order == null)
                return;
            OrdersForAproval.Remove(order);
            dataBase.Set(nameof(OrdersForAproval), new List<Order>(OrdersForAproval));
            order.status = true;
            observable.NotifyObservers(order);
            
        }

        public void Update(Order data)
        {
            if(!data.status)
            {
                OrdersForAproval.Add(data);
                dataBase.Set(nameof(OrdersForAproval), new List<Order>(OrdersForAproval));

            }
        }
    }
}
