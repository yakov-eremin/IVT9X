using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_2_QA;

namespace UnitTests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void SumOfSquaresTest()
        {
            int expected = 30;
            int actual = FunctionClass.SumOfSquares(4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FactorialTest()
        {
            int expected = 120;
            int actual = FunctionClass.Factorial(5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void FibonachiTest()
        {
            int expected = 13;
            int actual = FunctionClass.Fibonachi(7);
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]

    public class ArrayTest
    {
        [TestMethod]
        public void MaxElementTest()
        {
            int[] array = { 10, 12, 152, 911, 76 };
            int expected = 911;
            int actual = ArrayClass.ArrayMaxElement(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinElementTest()
        {
            int[] array = { 10, 12, 152, 911, 76, -1 };
            int expected = -1;
            int actual = ArrayClass.ArrayMinElement(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AverageTest()
        {
            int[] array = { 10, 12, 76, 14 };
            double expected = 28;
            double actual = ArrayClass.ArrayAverage(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SumTest()
        {
            int[] array = { 10, 12, 76, 14 };
            int expected = 112;
            int actual = ArrayClass.ArraySum(array);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            int[] array = { 10, 12, 76, 14 };
            int expected = 127680;
            int actual = ArrayClass.ArrayMultiplication(array);
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void SumTest()
        {
            string expected = "Hello world";
            string str1 = "Hello";
            string str2 = "world";
            string actual = StringClass.SumString(str1,str2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindSymbolTest()
        {
            string str1 = "Hello world";
            char symbol = 'l';
            int expected = 3;
            int actual = StringClass.FindSymbol(str1, symbol);
            Assert.AreEqual(expected, actual);
        }
    }
}