using prog2_lab3.Command;
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
        OpenUCCommand OpenFirstPageCommand;
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
        public AdministratorViewModel()
        {
            //UserControls = new OrderApproval();
            OpenFirstPageCommand = new OpenUCCommand(OpenUC, new OrderApproval(), new OrderApprovalViewModel()); 
            OpenUC(new OrderApproval(), new OrderApprovalViewModel());
        }
        void OpenUC(UserControl userControl, object obj)
        {
            UserControls = userControl;
            UserControls.DataContext = obj;
        }
    }
}
