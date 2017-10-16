using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanCalculator.Utility;

namespace RomanCalculator.Validator
{
    public interface IInputValidator
    {
        bool RangeValidator(int input);
        bool CheckIfRomanCharacter(string roman);

    }
    public class InputValidator : IInputValidator
    {
        public bool RangeValidator(int input)
        {
            if (input > 0 && input < 4000)
                return true;
            return false;
        }

        public bool CheckIfRomanCharacter(string roman)
        {
            foreach (var entry in Data.AllCombinationDictionary)
            {

                while (roman.StartsWith(entry.Value))
                {
                    roman = roman.Substring(entry.Value.Length);
                }
            }

            return string.IsNullOrEmpty(roman);
        }

    }
}
