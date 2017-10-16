using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanCalculator.Validator;

namespace RomanCalculator.Services
{
    public interface IProcessor
    {
        string AddRomanNumbers(string firstNumber, string secondNumber);
    }
    public class Processor : IProcessor
    {
        private readonly ICalculator _calculator;
        private readonly IInputValidator _inputValidator;
        private readonly INumberConverter _romanToNumbers;

        private const string SumError = "Sum is out of range, can't be converted.";
        private const string NotRomanError = " is Not Valid Roman Number.";

        public Processor(ICalculator calculator,IInputValidator inputValidator, INumberConverter romanToNumbers)
        {
            _calculator = calculator;
            _inputValidator = inputValidator;
            _romanToNumbers = romanToNumbers;
        }


        public string AddRomanNumbers(string firstNumber, string secondNumber)
        {
            if (!_inputValidator.CheckIfRomanCharacter(firstNumber))
                return firstNumber + NotRomanError;
            if (!_inputValidator.CheckIfRomanCharacter(secondNumber))
                return secondNumber + NotRomanError;

            var firstIntFromRoman = _romanToNumbers.ConvertFromRoman(firstNumber.ToUpper());

            var secondIntFromRoman = _romanToNumbers.ConvertFromRoman(secondNumber.ToUpper());

            var sum = _calculator.AddNumbers(firstIntFromRoman, secondIntFromRoman);
            if (!_inputValidator.RangeValidator(sum))
                return SumError;

            var romanWord = new StringBuilder();
            romanWord = _romanToNumbers.ConvertToRoman(sum, romanWord);

            return romanWord.ToString();

        }
    }
}
