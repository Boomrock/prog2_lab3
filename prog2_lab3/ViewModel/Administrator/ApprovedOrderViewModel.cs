using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.Abstract.Observer;
using prog2_lab3.Models.realisation.DataBase;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class ApprovedOrderViewModel:ViewModel, IObserver<Order>
    {
        
        IDataBase<object> dataBase;
        IObservable<Order> observable;
        public ObservableCollection<Order> ApprovedOrders { get; set; }
        public ApprovedOrderViewModel(IDataBase<object> dataBase, IObservable<Order> observable)
        {
            this.dataBase = dataBase;
            this.observable = observable;
            observable.AddObserver(this);
            ApprovedOrders = new ObservableCollection<Order>((Order[])dataBase.Get("ApprovedOrders"));
            ApprovedOrders = new ObservableCollection<Order>((Order[])dataBase.Get(nameof(ApprovedOrders)));
          // eventHendler.Invoke(new Order(2, Сategories.SecondCatigory, new Models.realisation.
          // ("neJan", "cherezov", "andreevich", 2, "rqt", "123"), true));
        }
        public void Update(Order data)
        {
            if (data.status)
            {
                ApprovedOrders.Add(data);
                dataBase.Set(nameof(ApprovedOrders), (List<Order>)ApprovedOrders.GetEnumerator());
            }
        }
    }
}
