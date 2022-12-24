using prog2_lab3.Command;
using prog2_lab3.Models;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation.DataBase;
using prog2_lab3.View.Administrator_view_UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;


namespace prog2_lab3.ViewModel.Administrator
{
    class AdministratorViewModel: ViewModel
    {
        
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }
        UserControl userControls;
        Action<Order> Notify;
        List<Order> ApprovedOrders;
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
            ApprovedOrders = new List<Order> {
                    new Order(1,Сategories.SecondCatigory, new Models.realisation.Owner("jan", "cherezov","andreevich"), true),
            };
            string path = $"C:\\Users\\федор\\Desktop\\DataBaseJson.txt";
            IDataBase<List<Order>> dataBaseOrder = new DataBaseJsone<List<Order>>();
            dataBaseOrder.Connect(path);
            dataBaseOrder.Set(nameof(ApprovedOrders), ApprovedOrders);
            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new ApprovedOrder(), new ApprovedOrderViewModel(dataBaseOrder, ref Notify));
            OpenFirstUCCommand  = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(dataBaseOrder, ref Notify));
        }
        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
        
    }
}
