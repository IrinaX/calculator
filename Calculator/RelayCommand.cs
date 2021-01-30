using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _executeMethod;

        public RelayCommand(Action<object> executeMethod)
        {
            _executeMethod = executeMethod;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
