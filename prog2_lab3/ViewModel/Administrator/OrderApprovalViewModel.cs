using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.Abstract.Observer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            catch (System.Exception)
            {
            }
            OrdersForAproval.Add(new Order(3, Categories.TestCategory, new Models.realisation.User("a", "a", "a"), true));
            AprovalCommand = new RelayCommand<Order>(ArovalOrder);
        }
        private void ArovalOrder(Order order)
        {
            
            OrdersForAproval.Remove(order);
            order.status = true;
            observable.NotifyObservers(order);
            dataBase.Set(nameof(OrdersForAproval), (List<Order>)OrdersForAproval.GetEnumerator());
        }

        public void Update(Order data)
        {
        }
    }
}
