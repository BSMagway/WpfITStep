using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework02Task02
{
    public partial class MainWindow : Window
    {
        private const int DEFAULT_NUMBER_FOR_ENTER = 30;
        private void ReactionByNumberClick(int number)
        {
            if (operatorExpression == 0 && expressionPreview.Text.Length == 0 || operatorExpression > 0)
            {
                if (double.TryParse(numberPreview.Text, out double result) && result == 0 && !pointTrigger)
                {
                    MessageBox.Show("Enter - ,", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (numberPreview.Text.Length == DEFAULT_NUMBER_FOR_ENTER)
                    {
                        MessageBox.Show($"Maximum - {DEFAULT_NUMBER_FOR_ENTER} number", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        numberPreview.Text += $"{number}";
                    }
                }
            }
        }

        private void ReactionByOperationClick(int number)
        {
            if (operatorExpression == 0)
            {
                if (!deleteOperationTrigger && numberOne == null)
                {
                    numberOne = double.Parse(numberPreview.Text);
                }

                deleteOperationTrigger = false;

                if (expressionPreview.Text.Length == 0)
                {
                    expressionPreview.Text += numberPreview.Text;
                }

                numberPreview.Text = "";
                pointTrigger = false;
                operatorExpression = number;

                switch (number)
                {
                    case 1:
                        expressionPreview.Text += " + ";
                        break;
                    case 2:
                        expressionPreview.Text += " - ";
                        break;
                    case 3:
                        expressionPreview.Text += " / ";
                        break;
                    case 4:
                        expressionPreview.Text += " * ";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
