using prog2_lab3.Command;
using prog2_lab3.Models.Abstract;
using prog2_lab3.Models.realisation.DataBase;
using prog2_lab3.View.UserViewUC;
using prog2_lab3.ViewModel.UserUC;
using prog2_lab3.Models.realisation;
using System.Windows.Controls;
using System;
using System.Collections.Generic;

namespace prog2_lab3.ViewModel
{

    class UserViewModel:ViewModel
    {
        public OpenUCCommand OpenFirstUCCommand { get; set; }
        public OpenUCCommand OpenSecondUCCommand { get; set; }


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

            OpenFirstUCCommand = new OpenUCCommand(OpenUC, new MakeOrderUC(), new MakeOrderViewModel(dataBase, user));
        }

     


        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
    }
}
