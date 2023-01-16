using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Controls;

namespace prog2_lab3.ViewModel.UserUC
{
    internal class UserOrderUCViewModel:ViewModel, prog2_lab3.Models.Abstract.Observer.IObserver<Order>
    {
        private IDataBase<object> dataBase;
        private User user;
        public ObservableCollection<Order> Order { get; set; }
        public UserOrderUCViewModel(IDataBase<object> dataBase, User user, prog2_lab3.Models.Abstract.Observer.IObservable<Order> observable)
        {
            observable.AddObserver(this);
            this.dataBase = dataBase;
            this.user = user;
            List<Order> temporary = new List<Order>();
            List<Order> UsersOrders = new List<Order>();
            try
            {
                temporary.AddRange((List<Order>)dataBase.Get("OrdersForApproval"));

            }
            catch(Exception ex) { }
            try
            {
                temporary.AddRange((List<Order>)dataBase.Get("ApprovedOrders"));
            }
            catch (Exception ex) { }
            Order = new ObservableCollection<Order>();
            foreach (var item in temporary)
            {
                if (item.User.Id == user.Id)
                    Order.Add(item);
            }
            
            OnPropertyChanged(nameof(Order));

        }

        public void Update(Order data)
        {
            if (!Order.Contains(data))
                Order.Add(data);
        }
    }
}
