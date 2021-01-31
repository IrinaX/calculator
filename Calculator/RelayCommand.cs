using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    class RelayCommand : ICommand //вместо событий клик, в mvvm используют команды.
    {
        public event EventHandler CanExecuteChanged; // вызывается при изменении условий, указывающий, может ли команда выполняться.
        Action<object> _executeMethod;

        public RelayCommand(Action<object> executeMethod) //конструктор класса RelayCommand
        {
            _executeMethod = executeMethod; // (?) локальному _executeMethod присваиваем метод который хотим выполнить при создании экземпляра класса RelayCommand
        }
        public bool CanExecute(object parameter) //определяет, может ли команда выполняться
        {
            return true; //если false, то кнопка будет в состоянии disabled
        }

        public void Execute(object parameter) //собственно выполняет логику команды
        {
            _executeMethod(parameter);//выполняемый метод с параметром
        }
    }
}
