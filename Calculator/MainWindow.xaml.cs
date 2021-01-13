using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool operationBtnPressed = false;
        private double savedValue = 0;
        //private double pastValue = 0;
        private int operationBtnCounter = 0;//фиксит баг с операциями: когда тыкаешь на разные операции это влияет на рез-т
        private string operation = string.Empty;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (textResult.Text == "0" || operationBtnPressed)
            {
                textResult.Text = btn.Content.ToString();
                operationBtnPressed = false;
            }
            else
            {
                textResult.Text += btn.Content.ToString();
            }
            operationBtnCounter = 0;
        }

        private void operation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            operationBtnCounter++;
            if (operationBtnCounter < 2)
            {
                calc();
            }
            operation = btn.Content.ToString();//last btn pressed sign
            savedValue = Double.Parse(textResult.Text);
            operationBtnPressed = true;
        }

        public void calc()
        {
            if (savedValue != 0)
            {
                switch (operation)
                {
                    case "+":
                        textResult.Text = (savedValue + Double.Parse(textResult.Text)).ToString();
                        break;
                    case "-":
                        textResult.Text = (savedValue - Double.Parse(textResult.Text)).ToString();
                        break;
                    case "*":
                        textResult.Text = (savedValue * Double.Parse(textResult.Text)).ToString();
                        break;
                    case "/":
                        textResult.Text = (savedValue / Double.Parse(textResult.Text)).ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            //pastValue = Double.Parse(textResult.Text);
            calc();
            savedValue = 0;
            operationBtnPressed = false;
            operationBtnCounter = 0;
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            textResult.Text = "0";
            savedValue = 0;
            //pastValue = 0;
            operationBtnPressed = false;
            operationBtnCounter = 0;
            operation = string.Empty;
        }
    }
}
