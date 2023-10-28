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

namespace comp_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNum, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            acBtn.Click += AcBtn_Click;
            negativeBtn.Click += NegativeBtn_Click;
            percentageBtn.Click += Percentage_Click;
            equalsBtn.Click += EqualsBtn_Click;


        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNum;
            if (double.TryParse(resultLabel.Content.ToString(), out newNum))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = Math.Add(lastNum, newNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = Math.Substract(lastNum, newNum);
                        break;
                    case SelectedOperator.Multiplication:
                        result = Math.Multiply(lastNum, newNum);
                        break;
                    case SelectedOperator.Division:
                        result = Math.Divide(lastNum, newNum);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNum))
            {
                lastNum = lastNum / 100;
                resultLabel.Content = lastNum.ToString();
            }
        }
        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNum))
            {
                lastNum = lastNum * -1;
                resultLabel.Content = lastNum.ToString();   
            }
        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNum)) 
            {
                resultLabel.Content = "0";

            }
            if (sender == multiplyBtn) selectedOperator = SelectedOperator.Multiplication;
            if (sender == divideBtn) selectedOperator = SelectedOperator.Division;
            if (sender == addBtn) selectedOperator = SelectedOperator.Addition;
            if (sender == minusBtn) selectedOperator = SelectedOperator.Subtraction;
        }

        private void decimalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // break
            } 
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    // creating a new type
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public class Math
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Substract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Dividing by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}
