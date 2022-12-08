using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace prog2_lab3.Command
{
    class OpenUCCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<UserControl, object> execute;
        UserControl userControl;
        object dataContext;
        public OpenUCCommand(Action<UserControl, object> execute, UserControl userControl, object dataContext)
        {
            this.userControl = userControl;
            this.execute = execute;
            this.dataContext = dataContext;
        }
        public bool CanExecute(object parameter)
        {
            return userControl != null;
        }

        public void Execute(object parameter)
        {
            execute.Invoke(userControl, dataContext);
        }
    }
}
