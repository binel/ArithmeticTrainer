using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticTrainer
{
    public static class DigitCounter
    {
        public static int GetNumDigits(int n)
        {
            // We are going to use log 10 (n) and that doesn't work for 0.
            if (n == 0)
            {
                return 1;
            }

            return (int)Math.Log10(Math.Abs((double)n)) + 1;
        }

        public static int GetSmallestIntOfLength(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("No integers have length 0 or less");
            }
    
            return (int)Math.Pow(10, length - 1);

            
        }
    }
}
