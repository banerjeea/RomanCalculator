using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanCalculator.Services;
using RomanCalculator.Validator;

namespace Test.RomanCalculator
{
    [TestClass]
    public class ProcessorTest
    {
        private  ICalculator _calculator;
        private  IInputValidator _inputValidator;
        private  INumberConverter _romanToNumbers;
        private IProcessor _processor;

        [TestInitialize]
        public void Init()
        {
           _calculator = new Calculator();
           _inputValidator =  new InputValidator();
           _romanToNumbers = new NumberConverter();
           _processor = new Processor(_calculator,_inputValidator,_romanToNumbers);
        }

        [TestMethod]
        public void TestSumOfNumbersForValidEntry()
        {
          var sum =  _processor.AddRomanNumbers("MCC", "MCC");
          Assert.AreEqual(sum,"MMCD");
        }
    }
}
