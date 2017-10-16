using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RomanCalculator.Utility;

namespace RomanCalculator.Services
{
    public interface INumberConverter
    {
        int ConvertFromRoman(string romanNumber);
        StringBuilder ConvertToRoman(int number, StringBuilder word);

    }
    public class NumberConverter : INumberConverter
    {
        //readonly Dictionary<int, string> _allCombinationDict = new Dictionary<int, string>
        //    {
        //        { 1000, "M" } ,
        //        { 900,  "CM" } ,
        //        { 500,  "D" } ,
        //        { 400,  "CD" } ,
        //        { 100,  "C" } ,
        //        { 90,   "XC" } ,
        //        { 50,   "L" } ,
        //        { 40,   "XL" } ,
        //        { 10,   "X" } ,
        //        { 9,    "IX" } ,
        //        { 5,    "V" } ,
        //        { 4,    "IV" } ,
        //        { 1,    "I" } ,
        //    };

        private int _counter = 0;

        
        public int ConvertFromRoman(string romanNumber)
        {
            int numberValue = 0;

            while (romanNumber.Length != 0)
            {
                foreach (var element in Data.AllCombinationDictionary)
                {
                    if (romanNumber.StartsWith(element.Value))
                    {
                        numberValue += element.Key;
                        romanNumber = romanNumber.Substring(element.Value.Length);
                    }
                }
            }
            return numberValue;
        }

        public StringBuilder ConvertToRoman(int number, StringBuilder word)
        {
            if (number <= 0)
            {
                return word;
            }

            var dictkey = Data.AllCombinationDictionary.ElementAt(_counter).Key;
            var dictVal = Data.AllCombinationDictionary.ElementAt(_counter).Value;


            if (number >= dictkey)
            {
                word.Append(dictVal);
                number -= dictkey;
                return ConvertToRoman(number, word);
            }
            else
            {
                _counter++;
                return ConvertToRoman(number, word);

            }
        }
    }
}
