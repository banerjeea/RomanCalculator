using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanCalculator.Services;
using RomanCalculator.Validator;

namespace RomanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Roman Number : ");
            var firstValue = Console.ReadLine();

            Console.WriteLine("Enter Second Roman Number : ");
            var secondNumber = Console.ReadLine();

            INumberConverter romanToNumbers = new NumberConverter();
            IInputValidator inputValidator = new InputValidator();
            ICalculator calculator = new Calculator();

            IProcessor processor = new Processor(calculator, inputValidator,romanToNumbers);

            Console.WriteLine("Sum of Two Numbers : " + processor.AddRomanNumbers(firstValue, secondNumber));
            Console.ReadKey();
        }
    }
}
