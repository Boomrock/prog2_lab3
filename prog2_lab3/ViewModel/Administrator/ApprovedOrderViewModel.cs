using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class ApprovedOrderViewModel:ViewModel
    {
        
        IDataBase<List<Order>> dataBase;
        public ObservableCollection<Order> ApprovedOrders { get; set; }
        public ApprovedOrderViewModel(IDataBase<List<Order>> dataBase, ref Action<Order> NotifyChangeApproved)
        {
            this.dataBase = dataBase;
            ApprovedOrders = new ObservableCollection<Order>();
            ApprovedOrders = new ObservableCollection<Order>(dataBase.Get(nameof(ApprovedOrders)));
            NotifyChangeApproved += AddElement;
          // eventHendler.Invoke(new Order(2, Сategories.SecondCatigory, new Models.realisation.Owner("neJan", "cherezov", "andreevich", 2, "rqt", "123"), true));
        }
        void AddElement(Order order)
        {
            ApprovedOrders.Add(order);
            dataBase.Set(nameof(ApprovedOrders), (List<Order>)ApprovedOrders.GetEnumerator());
        }


    }
}
