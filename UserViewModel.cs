using prog2_lab3.Command;
using prog2_lab3.View.UserViewUC;
using prog2_lab3.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace prog2_lab3.ViewModel
{

    class UserViewModel:ViewModel
    {
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }
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

        public UserViewModel()
        {
         
            OpenSecondUCCommand = new OpenUCCommand(OpenUC, new MakeOrder(), new MakeOrderViewModel());
            //OpenFirstUCCommand = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel(dataBaseOrder, ref Notify));
        }

     


        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
    }
}
