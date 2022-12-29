using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace prog2_lab3.Command
{
    class RelayCommand<T> :ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<T> execute;
        
        
        public RelayCommand(Action<T> execute)
        {
           
            this.execute = execute;
        
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke((T)parameter);
        }
    }
    class RelayCommand: ICommand
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
