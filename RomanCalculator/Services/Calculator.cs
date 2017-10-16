using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalculator.Services
{
    public interface ICalculator
    {
        int AddNumbers(int firstVal, int secondVal);
    }
    public class Calculator : ICalculator
    {

        public int AddNumbers(int firstVal, int secondVal)
        {

            return (firstVal + secondVal);
        }

        public int SubtractNumbers(int firstVal, int secondVal)
        {

            return (firstVal - secondVal);
        }
    }
}
