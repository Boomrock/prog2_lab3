using prog2_lab3.Command;
using prog2_lab3.Models.Abstract;
using prog2_lab3.View.UserViewUC;
using prog2_lab3.ViewModel.UserUC;
using prog2_lab3.Models.realisation;
using System.Windows.Controls;
using System;
using prog2_lab3.Models.realisation.Observer;
using prog2_lab3.Models;
namespace prog2_lab3.ViewModel
{

    class UserViewModel:ViewModel
    {
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }
        public Observable<Order> observable;


        private readonly IDataBase<object> dataBase;
        UserControl userControls;
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

        public UserViewModel(User user, IDataBase<object> dataBase)
        {
            if(dataBase == null)
            {
                throw new ArgumentNullException("dataBase");
            }
            this.dataBase = dataBase;
            observable = new Observable<Order>();
            OpenFirstUCCommand = new OpenUCCommand(OpenUC, new MakeOrderUC(), new MakeOrderViewModel(dataBase, user, observable));
            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new UserOrderUC(), new UserOrderUCViewModel(dataBase, user, observable));
        }

     


        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
    }
}
