using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorialsum
{
    public class Factorialsum
    {
        /**
         * Calculate factorial for a given input number
         * @param num, the input number
         */
        public long CalculateFactorial(int num)
        {
            if(num < 0)
            {
                throw new NegativeInputException("Negative input provided for factorial calculation", num);
            }

            long factorial = 1;
            for (int i = num; i > 0; i--)
            {
                factorial *= i;
            }
            return factorial;
        }

        /**
         * Separate an non zero input number into its individual non zero digits and stores them 
         * in a list
         * 
         * @param num, the input number
         * @param digitList, the list to hold the individual digits
         */
        public void SeparateIndividualNonZeroDigit(long num, List<long> digitList)
        {
            if (num < 0)
            {
                throw new NegativeInputException("Negative input provided in SeparateIndividualDigit", num);
            }
            else if(num == 0)
            {
                throw new InvalidZeroInputException("Zero input is not accepted in SeperateIndividualDigit");
            }

            int pow = (int)Math.Floor(Math.Log10(num)); 
            long digit = num / ((long)Math.Pow(10, pow)); // Compute digit
            digitList.Add(digit);
            num = num - ((long)Math.Pow(10, pow) * digit);

            if (num > 0)
            {
                SeparateIndividualNonZeroDigit(num, digitList);
            }
        }

        /**
         * Computes factorial of a given positive input integer and calculates 
         * the sum of the individual digits of the factorial (factorial sum)
         * 
         * @param num, the input integer
         * @return factorialSum, the factorial sum
         */
        public long FactorialSum(int num)
        {
            long factorial = 0;
            long factorialSum = 0;
            List<long> digitList = new List<long>();
            try
            {
                factorial = CalculateFactorial(num);
                SeparateIndividualNonZeroDigit(factorial, digitList);
                foreach(long digit in digitList)
                {
                    factorialSum += digit;
                }
            }
            catch (NegativeInputException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return factorialSum;
        }
    }

    /**
     * ClassName: NegativeInputException 
     * 
     * Custom exception thrown when negative input is provided for 
     * cases where only positive is valid 
     */
    public class NegativeInputException : Exception
    {
        public long InputValue
        {
            get;
        }
        /**
         * Default constructor
         */
        public NegativeInputException()
        {
        }

        /**
         * Constructor
         * 
         * @param message, the exception message
         */
        public NegativeInputException(string message) : base(message)
        {
        }

        /**
         * Constructor
         * 
         * @param message, the exception message
         * @param inputvalue, the value of the input that caused the exception
         */
        public NegativeInputException(string message, long inputValue) : base(message)
        {
            InputValue = inputValue;
        }

    }

    /**
    * ClassName: InvalidZeroInputException 
    * 
    * Custom exception thrown when input 0 is provided for 
    * cases where only 0 as an input is invalid 
    */
    public class InvalidZeroInputException : Exception
    {
        /**
         * Default constructor
         */
        public InvalidZeroInputException()
        {
        }

        /**
         * Constructor
         * 
         * @param message, the exception message
         */
        public InvalidZeroInputException(string message) : base(message)
        {
        }
    }
}
