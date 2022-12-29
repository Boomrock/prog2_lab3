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
       
        //комманда для открытия первой UC 
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        //комманда для открытия второй UC 
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
            //путь до базы данных 
            string path = $".\\DataBaseJson.txt";
            //наблюдатель для первой и второй UC
            observable = new Observable<Order>();
            //База данных
            IDataBase<object> dataBase = new DataBaseJsone();
            //Соединение с базой данных
            dataBase.Connect(path);
            //комманда для открытия первой UC
            OpenFirstUCCommand = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(dataBase, observable));
            //комманда для открытия второй UC
            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new ApprovedOrder(), new ApprovedOrderViewModel(dataBase, observable));

        }
        /// <summary>
        /// Method for open UC
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="dataContext"></param>
        void OpenUC(UserControl userControl, object dataContext)
        {
            UserControls = userControl;
            UserControls.DataContext = dataContext;
        }
        
    }
}
