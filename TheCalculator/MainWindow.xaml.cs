using System;
using System.Windows;
using System.Windows.Controls;

namespace TheCalculator
{
    public partial class MainWindow : Window
    {
        private string currentInput = "0";
        private string currentOperator = "";
        private double result = 0;
        private bool isOperatorClicked = false;
        private string currentExpression = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            currentInput = "0";
            result = 0;
            currentOperator = "";
            currentExpression = "";
            KeyPressedText.Text = "";
            EnteredNumberText.Text = "0";
        }
        private void ClearCEButtonClick(object sender, RoutedEventArgs e)
        {
            currentInput = "0";
            EnteredNumberText.Text = currentInput;
        }
        private void NullButtonClick(object sender, RoutedEventArgs e)
        {
            currentInput = "0";
            EnteredNumberText.Text = currentInput;
        }

        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.CommandParameter.ToString();

            if (currentInput == "0" || isOperatorClicked)
            {
                currentInput = number;
                isOperatorClicked = false;
            }
            else
            {
                currentInput += number;
            }

            EnteredNumberText.Text = currentInput;
            currentExpression += number;
            KeyPressedText.Text = currentExpression;
        }

        private void OperatorButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operatorSymbol = button.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(currentOperator))
            {
                Calculate();
                currentExpression = result.ToString();
            }
            else
            {
                result = double.Parse(currentInput);
            }

            currentOperator = operatorSymbol;
            isOperatorClicked = true;

            currentExpression += operatorSymbol;
            KeyPressedText.Text = currentExpression;
        }

        private void DecimalPointClick(object sender, RoutedEventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                EnteredNumberText.Text = currentInput;
                currentExpression += ".";
                KeyPressedText.Text = currentExpression;
            }
        }

        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            Calculate();
            currentOperator = "";
            isOperatorClicked = true;
            KeyPressedText.Text = currentExpression;
        }

        private void Calculate()
        {
            double input = double.Parse(currentInput);

            switch (currentOperator)
            {
                case "+":
                    result += input;
                    break;
                case "-":
                    result -= input;
                    break;
                case "*":
                    result *= input;
                    break;
                case "/":
                    if (input != 0)
                    {
                        result /= input;
                    }
                    else
                    {
                        currentInput = "Error";
                        EnteredNumberText.Text = currentInput;
                        return;
                    }
                    break;
            }

            currentInput = result.ToString();
            EnteredNumberText.Text = currentInput;
        }
    }
}
