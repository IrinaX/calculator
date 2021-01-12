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
        double value = 0;
        string operation = "";
        bool operation_pressed = false;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((result.Text == "0") || (operation_pressed))
            {
                result.Clear();
                operation_pressed = false;
            }
            Button b = (Button)sender;
            result.Text += b.Content;
        }
        
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            result.Text = "0";
        }
        private void Button_Operation(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            operation = (string)b.Content;
            value = Double.Parse(result.Text);
            operation_pressed = true;
        }
        private void Button_Equal(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                        result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
            }
            operation_pressed = false;
        }
    }
}
