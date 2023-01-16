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
        private ObservableCollection<Order> ordersForApproval;
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

        public ObservableCollection<Order> OrdersForApproval { get => ordersForApproval; set => ordersForApproval = value; }
        #endregion 


        public OrderApprovalViewModel(IDataBase<object> dataBase, IObservable<Order> observable)
        {
            this.dataBase = dataBase;
            this.observable = observable;
            observable.AddObserver(this);
            OrdersForApproval = new ObservableCollection<Order>();
            try
            {
                OrdersForApproval = new ObservableCollection<Order>((List<Order>)dataBase.Get(nameof(OrdersForApproval)));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n code: 416857454867787");
            }
            AprovalCommand = new RelayCommand<Order>(AprovalOrder);
        }
        private void AprovalOrder(Order order)
        { 
            if (order == null)
                return;
            OrdersForApproval.Remove(order);
            dataBase.Set(nameof(OrdersForApproval), new List<Order>(OrdersForApproval));
            order.status = true;
            observable.NotifyObservers(order);
            
        }

        public void Update(Order data)
        {
            if(!data.status)
            {
                OrdersForApproval.Add(data);
                dataBase.Set(nameof(OrdersForApproval), new List<Order>(OrdersForApproval));

            }
        }
    }
}
