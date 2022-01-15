using System;

namespace Homework02Task02
{
    public static class Calculator
    {
        public static double? Plus(double? numberOne, double? numberTwo) => numberOne + numberTwo;

        public static double? Minus(double? numberOne, double? numberTwo) => numberOne - numberTwo;

        public static double? Multiply(double? numberOne, double? numberTwo) => numberOne * numberTwo;

        public static double? Divide(double? numberOne, double? numberTwo)
        {
            if (numberTwo == 0)
            {
                throw new DivideByZeroException("Divide by zero");
            }

            return numberOne / numberTwo;
        }
    }
}
