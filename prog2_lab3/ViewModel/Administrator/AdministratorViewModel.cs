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
        List<Order> orders;
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
                orders = new List<Order> {
                    new Order(1,Сategories.SecondCatigory, new Models.realisation.Owner("jan", "cherezov","andreevich",1, "rqt","123"), false),
                };
            string path = $"C:\\Users\\федор\\Desktop\\DataBaseJson.txt";
            IDataBase dataBase = new DataBaseJsone();
            dataBase.Connect(path);
            dataBase.Set(nameof(orders), orders.GetType().ToString(), orders);

            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new ApprovedOrder(), new ApprovedOrderViewModel(dataBase));
            OpenFirstUCCommand  = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(orders, ref Notify));
        }
        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
        
    }
}
