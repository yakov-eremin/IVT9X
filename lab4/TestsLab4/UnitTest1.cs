using NUnit.Framework;
using lab4;

namespace TestsLab4
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateClass ()
        {
            Calculate calc = new Calculate();
            Assert.NotNull(calc);
        }
        [Test]
        public void TestMethodSumm()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(7.8, calc.Summ(2.5, 5.3));
        }
        [Test]
        public void TestMethodSubtraction()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(1.2, calc.Subtraction(2.5, 1.3));
        }
        [Test]
        public void TestMethodMultiplication()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(1.44, calc.Multiplication(1.2, 1.2));
        }
        [Test]
        public void TestMethodDivision()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(1, calc.Division(1.2, 1.2));
        }
        [Test]
        public void TestMethodSortingMax()
        {
            Calculate calc = new Calculate();
            double[] arr = new double[3];
            arr[0] = 3; arr[1] = 15; arr[2] = 10;
            double summ = calc.SortingMax(arr, 3);
            Assert.AreEqual(15, summ);
        }
        [Test]
        public void TestMethodSortingMin()
        {
            Calculate calc = new Calculate();
            double[] arr = new double[4];
            arr[0] = 5; arr[1] = 3; arr[2] = 7; arr[3] = 13;
            double summ = calc.SortingMin(arr, 4);
            Assert.AreEqual(3, summ);
        }
        [Test]
        public void TestMethodSortingSumm()
        {
            Calculate calc = new Calculate();
            double[] arr = new double[4];
            arr[0] = 10; arr[1] = 5; arr[2] = 3; arr[3] = 11;
            double summ = calc.SortingSumm(arr, 4);
            Assert.AreEqual(29, summ);
        }

    }
}