using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.Abstract.Observer;
using prog2_lab3.Models.realisation.DataBase;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

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
            try
            {
            ApprovedOrders = new ObservableCollection<Order>((List<Order>)dataBase.Get("ApprovedOrders"));

            }
            catch (System.Exception ex )
            {
                MessageBox.Show(ex.StackTrace + "\n code: 48489743546873654");
                ApprovedOrders = new ObservableCollection<Order>();
            }

          // eventHendler.Invoke(new Order(2, Сategories.SecondCatigory, new Models.realisation.
          // ("neJan", "cherezov", "andreevich", 2, "rqt", "123"), true));
        }
        public void Update(Order data)
        {
            if (data.status)
            {
                ApprovedOrders.Add(data);
                dataBase.Set(nameof(ApprovedOrders), new List<Order>(ApprovedOrders));
            }
        }
    }
}
