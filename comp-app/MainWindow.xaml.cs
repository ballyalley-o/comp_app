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
        double lastNumber, result;
        public MainWindow()
        {
            InitializeComponent();

            acBtn.Click += AcBtn_Click;
            negativeBtn.Click += NegativeBtn_Click;
            percentageBtn.Click += Percentage_Click;


        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber)) ;
            {
                lastNumber = lastNumber / 0;
                resultLabel.Content = lastNumber.ToString();
            }
        }
        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber));
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber;   
            }
        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void sevenBtn_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }
        }
    }
}
