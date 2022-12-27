using Newtonsoft.Json;
using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation;
using prog2_lab3.Models.realisation.DataBase;
using prog2_lab3.Models.realisation.Observer;
using prog2_lab3.View.Administrator_view_UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Controls;


namespace prog2_lab3.ViewModel.Administrator
{
    class AdministratorViewModel: ViewModel
    {
        
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }
        UserControl userControls;
        IDataBase<object> dataBaseOrder;
        Action<Order> Notify;
        List<Order> OrdersForAproval;
        Observable<Order> observable;
        public UserControl UserControls
        {
            get
            {
                return userControls;
            }
            set
            {
                userControls = value;
                OnPropertyChanged("UserControls");
            }
        }
        public AdministratorViewModel()
        {
            observable = new Observable<Order>();
/*            OrdersForAproval = new List<Order> {
                    new Order(1,Categories.SecondCatigory, new User("jan", "cherezov","andreevich"), false),
                     new Order(1,Categories.SecondCatigory, new User("jan", "cherezov","andreevich"), false),
            };*/
            string path = $".\\DataBaseJson.txt";
            IDataBase<object> dataBaseOrder = new DataBaseJsone();
            dataBaseOrder.Connect(path);
           // dataBaseOrder.Set(nameof(OrdersForAproval), OrdersForAproval);
            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new ApprovedOrder(), new ApprovedOrderViewModel(dataBaseOrder, observable));
            OpenFirstUCCommand  = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(dataBaseOrder, observable));
        }
        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
        
    }
}
