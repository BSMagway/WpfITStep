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

namespace Homework02Task02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double? numberOne = null;
        private double? numberTwo = null;
        private bool pointTrigger = false;
        private bool deleteOperationTrigger = false;
        private int operatorExpression = 0;

        private void Button_1_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(1);

        private void Button_2_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(2);

        private void Button_3_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(3);

        private void Button_4_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(4);

        private void Button_5_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(5);

        private void Button_6_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(6);

        private void Button_7_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(7);

        private void Button_8_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(8);

        private void Button_9_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(9);

        private void Button_0_Click(object sender, RoutedEventArgs e) => ReactionByNumberClick(0);

        private void Button_Plus_Click(object sender, RoutedEventArgs e) => ReactionByOperationClick(1);

        private void Button_Minus_Click(object sender, RoutedEventArgs e) => ReactionByOperationClick(2);

        private void Button_Divide_Click(object sender, RoutedEventArgs e) => ReactionByOperationClick(3);

        private void Button_Multiplier_Click(object sender, RoutedEventArgs e) => ReactionByOperationClick(4);

        private void Button_Point_Click(object sender, RoutedEventArgs e)
        {
            if (!pointTrigger && numberPreview.Text.Length > 0)
            {
                numberPreview.Text += ",";
                pointTrigger = true;
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (numberPreview.Text.Length > 0)
            {
                if (numberPreview.Text[numberPreview.Text.Length - 1] == ',')
                {
                    pointTrigger = false;
                }

                numberPreview.Text = numberPreview.Text.Remove(numberPreview.Text.Length - 1, 1);
            }
            else if (operatorExpression > 0)
            {
                expressionPreview.Text = expressionPreview.Text.Remove(expressionPreview.Text.Length - 3, 3);
                deleteOperationTrigger = true;
                operatorExpression = 0;
            }
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e)
        {
            if (numberPreview.Text.Length > 0)
            {
                numberPreview.Text = "";
                pointTrigger = false;
            }
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            numberOne = null;
            numberTwo = null;
            numberPreview.Text = "";
            expressionPreview.Text = "";
            pointTrigger = false;
            deleteOperationTrigger = false;
            operatorExpression = 0;
        }

        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            double? result = 0;
            if (double.TryParse(numberPreview.Text, out double number))
            {
                numberTwo = number;
            }

            if (numberOne != null && numberTwo != null)
            {
                switch (operatorExpression)
                {
                    case 1:
                        result = Calculator.Plus(numberOne, numberTwo);
                        break;
                    case 2:
                        result = Calculator.Minus(numberOne, numberTwo);
                        break;
                    case 3:
                        try
                        {
                            result = Calculator.Divide(numberOne, numberTwo);
                        }
                        catch (DivideByZeroException)
                        {
                            MessageBox.Show("Divide by zero", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                    case 4:
                        result = Calculator.Multiply(numberOne, numberTwo);
                        break;
                    default:
                        break;
                }

                expressionPreview.Text += $"{numberPreview.Text} = {result.ToString()}";
                numberPreview.Text = "";
                numberOne = result;
                numberTwo = null;
                operatorExpression = 0;
            }
        }
    }
}
