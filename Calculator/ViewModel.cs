using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    class ViewModel : INotifyPropertyChanged
    {
        private bool operationBtnPressed = false;
        private double savedValue = 0;
        private int operationBtnCounter = 0;//фиксит баг с операциями: когда тыкаешь на разные операции это влияет на рез-т
        private string operation = string.Empty;
        private int equalBtnCounter = 0;
        private double lastNumberBtnClicked = 0;


        public event PropertyChangedEventHandler PropertyChanged;//извещение об изменении свойств
        public void OnPropertyChanged([CallerMemberName] string prop = "") // извещение об изменении свойств
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        private string textResult;

        public string TextResult// свойство для текстового поля
        {
            get { return textResult; }
            set
            {// обработка изменения свойства
                textResult = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NumClickCommand { get; set; }//свойство

        public RelayCommand OperationClickCommand { get; set; }//свойство
        public RelayCommand EqualClickCommand { get; set; }//свойство
        public RelayCommand ClearClickCommand { get; set; }//свойство

        public ViewModel()//конструктор класса ViewModel
        {
            NumClickCommand = new RelayCommand(NumBtnClick);// экземпляр класса RelayCommand с параметром NumBtnClick
            OperationClickCommand = new RelayCommand(OperationBtnClick);// экземпляр класса RelayCommand с параметром OperationBtnClick
            EqualClickCommand = new RelayCommand(EqualBtnClick);//привязка метода, который должен выполняться при клике на кнопку =
            ClearClickCommand = new RelayCommand(ClearBtnClick);//привязка метода, который должен выполняться при клике на кнопку C
        }


        private void NumBtnClick(object parameter)//метод вызывается при клике на кнопки с номерами
        {
            string btnContent = Convert.ToString(parameter);

            if (TextResult == "0" || operationBtnPressed)
            {
                TextResult = btnContent;
                operationBtnPressed = false;
            }
            else
            {
                TextResult += btnContent;
            }
            lastNumberBtnClicked = Double.Parse(TextResult);
            operationBtnCounter = 0;
            equalBtnCounter = 0;
        }

        private void OperationBtnClick(object parameter)//метод вызывается при клике на кнопки с арифм. действиями
        {
            string btnContent = Convert.ToString(parameter);
            operationBtnCounter++;
            if (operationBtnCounter < 2 && equalBtnCounter < 2)
            {
                if (savedValue != 0)
                {
                    Calc(savedValue, Double.Parse(TextResult));
                }
            }
            operation = btnContent;//last btn pressed sign
            savedValue = Double.Parse(TextResult);
            operationBtnPressed = true;
            equalBtnCounter = 0;
        }

        private void EqualBtnClick(object parameter)//метод вызывается при клике на кнопку =
        {
            equalBtnCounter++;
            if (equalBtnCounter < 2)
            {
                if (savedValue != 0)
                {
                    Calc(savedValue, Double.Parse(TextResult));
                }
                savedValue = 0;
            }
            else
            {
                savedValue = lastNumberBtnClicked;
                Calc(Double.Parse(TextResult), lastNumberBtnClicked);

            }

            operationBtnPressed = false;
            operationBtnCounter = 0;
        }

        private void Calc(double firstVal, double secVal)//здесь производятся вычисления
        {
            switch (operation)
            {
                case "+":
                    TextResult = (firstVal + secVal).ToString();
                    break;
                case "-":
                    TextResult = (firstVal - secVal).ToString();
                    break;
                case "*":
                    TextResult = (firstVal * secVal).ToString();
                    break;
                case "/":
                    TextResult = (firstVal / secVal).ToString();
                    break;
                default:
                    break;
            }
        }

        private void ClearBtnClick(object parameter) //метод приводит все созданные переменные в изначальное состояние
        {
            TextResult = "0";
            operationBtnPressed = false;
            savedValue = 0;
            operationBtnCounter = 0;
            operation = string.Empty;
            equalBtnCounter = 0;
            lastNumberBtnClicked = 0;
        }
    }
}
