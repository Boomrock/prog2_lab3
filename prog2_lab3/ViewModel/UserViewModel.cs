using prog2_lab3.Command;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation.DataBase;
using prog2_lab3.View.UserViewUC;
using prog2_lab3.ViewModel.UserUC;
using prog2_lab3.Models.realisation;
using System.Windows.Controls;
using System.Collections.Generic;

namespace prog2_lab3.ViewModel
{

    class UserViewModel:ViewModel
    {
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }


        private IDataBase<object> deliveryParametrsDataBase;
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

        public UserViewModel(User user)
        {
            deliveryParametrsDataBase = new DataBaseJsone();
            deliveryParametrsDataBase.Connect("Path in File");

            //OpenSecondUCCommand = new OpenUCCommand(OpenUC, new MakeOrderUC(), new MakeOrderViewModel(deliveryParametrsDataBase, user));
            //OpenFirstUCCommand = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(dataBaseOrder, ref Notify));
        }

     


        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
    }
}
