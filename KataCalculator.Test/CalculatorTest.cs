using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataCalculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void EmptyString()
        {
            int result = Calculator.Add("");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void OneNumberString()
        {
            int result = Calculator.Add("1");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TwoNumbersString()
        {
            int result = Calculator.Add("1,2");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void UnlimitedNumbers()
        {
            int result = Calculator.Add("1,3,2,4,5,7,6,8");
            Assert.AreEqual(result, 36);
        }

        [TestMethod]
        public void NumbersWithNewLines()
        {
            int result = Calculator.Add("1\n2,3");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void NumbersWithDelimiter()
        {
            int result = Calculator.Add("//;\n1;2");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        [ExpectedException (typeof(System.ArgumentOutOfRangeException))]
        public void NegativeNumbers()
        {
            int result = Calculator.Add("//;\n-1;2\n-3");
        }

        [TestMethod]
        public void MaxNumbersLimitation()
        {
            int result = Calculator.Add("1\n2000,3;120");
            Assert.AreEqual(result, 124);
        }

        [TestMethod]
        public void UnlimitedDelimiters()
        {
            int result = Calculator.Add("//[***]\n1***2***3");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void MultipleDelimiters()
        {
            int result = Calculator.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(result, 6);
        }
    }
}
