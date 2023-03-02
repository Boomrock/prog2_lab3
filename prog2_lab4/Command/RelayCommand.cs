using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prog2_lab4.Command
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action execute;


        public RelayCommand(Action execute)
        {

            this.execute = execute;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
