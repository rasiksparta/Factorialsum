using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Factorialsum.Test
{
    [TestClass]
    public class UnitTest1
    {
        Factorialsum factorialSum = new Factorialsum();
        [TestMethod]
        public void TestCalculateFactorial()
        {
            Assert.AreEqual(1, factorialSum.CalculateFactorial(0));
            Assert.AreEqual(1, factorialSum.CalculateFactorial(1));
            Assert.AreEqual(720, factorialSum.CalculateFactorial(6));
            Assert.AreEqual(6227020800, factorialSum.CalculateFactorial(13));
            //Assert.ThrowsException<NegativeInputException>();
        }

        [TestMethod]
        public void TestCalculateSeparateIndividualDigit()
        {
            List<long> checkList = new List<long>();
            factorialSum.SeparateIndividualNonZeroDigit(12345, checkList);
            Assert.AreEqual(true ,CompareTwoArrays(new List<long>(new long[] { 1,2,3,4,5}), checkList));
            checkList.Clear();
            factorialSum.SeparateIndividualNonZeroDigit(25105, checkList);
            Assert.AreEqual(true, CompareTwoArrays(new List<long>(new long[] { 2, 5, 1, 5 }), checkList));
            checkList.Clear();
            factorialSum.SeparateIndividualNonZeroDigit(3628800, checkList);           
            Assert.AreEqual(true, CompareTwoArrays(new List<long>(new long[] { 3, 6, 2, 8, 8 }), checkList));
        }

        [TestMethod]
        public void TestFactorialSum()
        {
            Assert.AreEqual(9, factorialSum.FactorialSum(6));
            Assert.AreEqual(27, factorialSum.FactorialSum(10));
            Assert.AreEqual(27, factorialSum.FactorialSum(13));
            Assert.AreEqual(45, factorialSum.FactorialSum(15));
        }

        public bool CompareTwoArrays(List<long> listA, List<long> listB)
        {
            if(listA.Count != listB.Count)
            {
                return false;
            }

            foreach (long l in listA)
            {
                if (!listB.Contains(l))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
