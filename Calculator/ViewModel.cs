using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #region CalculatorVariables
        private bool operationBtnPressed = false;
        private double savedValue = 0;
        private int operationBtnCounter = 0;//фиксит баг с операциями: когда тыкаешь на разные операции это влияет на рез-т
        private string operation = string.Empty;
        private int equalBtnCounter = 0;
        private double lastNumberBtnClicked = 0;
        #endregion
        #region textResult
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
        #endregion
        #region CalculatorProps
        public RelayCommand NumClickCommand { get; set; }//свойство
        public RelayCommand OperationClickCommand { get; set; }//свойство
        public RelayCommand EqualClickCommand { get; set; }//свойство
        public RelayCommand ClearClickCommand { get; set; }//свойство
        #endregion
        #region ObservableCollections
        public ObservableCollection<SavedComponent> HistoryList { get; set; }
        public ObservableCollection<SavedComponent> MemoryList { get; set; }
        #endregion
        #region BtnIsideHistoryListProp
        public RelayCommand HistoryBtnClickCommand { get; set; }
        #endregion
        #region MemoryProps
        public RelayCommand MemoryClearClickCommand { get; set; }
        public RelayCommand MemoryReturnClickCommand { get; set; }
        public RelayCommand MemoryPlusClickCommand { get; set; }
        public RelayCommand MemoryMinusClickCommand { get; set; }
        public RelayCommand MemorySaveClickCommand { get; set; }
        #endregion

        public ViewModel()//конструктор класса ViewModel
        {
            TextResult = "0";
            #region CalculatorCommands
            NumClickCommand = new RelayCommand(NumBtnClick);// экземпляр класса RelayCommand(т.е объект) с параметром NumBtnClick 
            /*
             Команда хранится в свойстве  NumClickCommand и представляет собой объект класса RelayCommand. 
             Этот объект в конструкторе принимает действие - делегат Action<object> т.е. NumBtnClick.
            */
            OperationClickCommand = new RelayCommand(OperationBtnClick);// +-*/
            EqualClickCommand = new RelayCommand(EqualBtnClick);// =
            ClearClickCommand = new RelayCommand(ClearBtnClick);// C
            #endregion
            #region ListCreation
            HistoryList = new ObservableCollection<SavedComponent>();
            MemoryList = new ObservableCollection<SavedComponent>();
            #endregion
            #region BtnIsideHistoryListCommand
            HistoryBtnClickCommand = new RelayCommand(HistoryBtnClick);
            #endregion
            #region MemoryCommands
            MemoryClearClickCommand = new RelayCommand(MemoryClear);
            MemoryReturnClickCommand = new RelayCommand(MemoryReturn);
            MemoryPlusClickCommand = new RelayCommand(MemoryPlus);
            MemoryMinusClickCommand = new RelayCommand(MemoryMinus);
            MemorySaveClickCommand = new RelayCommand(MemorySave);
            #endregion
        }

        #region CalculatorMethods
        // в (object parameter) передается содержимое CommandParameter из xaml
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
            HistoryList.Insert(0, new SavedComponent(TextResult));//добавление компонента в журнал
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

        private void ClearBtnClick(object parameter) //метод приводит все созданные переменные в изначальное состояние, вызывается при клике на кнопку Clear
        {
            TextResult = "0";
            operationBtnPressed = false;
            savedValue = 0;
            operationBtnCounter = 0;
            operation = string.Empty;
            equalBtnCounter = 0;
            lastNumberBtnClicked = 0;
        }
        #endregion
        #region BtnInsideHistoryListMethod
        private void HistoryBtnClick(object btnContent)
        {
            TextResult = Convert.ToString(btnContent);
        }
        #endregion
        #region MemoryMethods
        private void MemoryClear(object obj)
        {
            MemoryList.Clear();
        }

        private void MemoryReturn(object obj)
        {
            if(MemoryList.Count != 0)
            {
                TextResult = MemoryList[0].ComponentValue;
            }
        }

        private void MemoryPlus(object obj)
        {
            if (MemoryList.Count != 0)
            {
                double componentValue = Double.Parse(MemoryList[0].ComponentValue) + lastNumberBtnClicked;
                
                MemoryList.RemoveAt(0);
                MemoryList.Insert(0, new SavedComponent(Convert.ToString(componentValue)));
            }
        }

        private void MemoryMinus(object obj)
        {
            if (MemoryList.Count != 0)
            {
                double componentValue = Double.Parse(MemoryList[0].ComponentValue) - lastNumberBtnClicked;

                MemoryList.RemoveAt(0);
                MemoryList.Insert(0, new SavedComponent(Convert.ToString(componentValue)));
            }
        }

        private void MemorySave(object obj)
        {
            MemoryList.Insert(0, new SavedComponent(TextResult));//добавление компонента в память
        }
        #endregion
    }

}
