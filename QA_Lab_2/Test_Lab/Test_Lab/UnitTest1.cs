using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_2;

namespace Test_Lab
{
    [TestClass]
    public class UnitTest_Init
    {
        [TestMethod]
        public void TestInitP() // Проверка инициализации положительного мнимого числа
        {
            Complex a = new Complex();
            a.Init(2, 0);
            int var = 2;
            Assert.AreEqual(var, a.ic);
        }

        [TestMethod]
        public void TestInitN()// Проверка инициализации отрицательного мнимого числа
        {
            Complex a = new Complex();
            a.Init(-2, 0);
            int var = -2;
            Assert.AreEqual(var, a.ic);
        }
    }
        [TestClass]
    public class UnitTest_Module
    {
        [TestMethod]
        public void TestModulePZ() // Проверка модуля комплексного числа, где вещественное > 0, а мнимое = 0
        {
            Complex a = new Complex();
            a.Init(2, 0);
            double module = a.Modul();
            int var = 2;
            Assert.AreEqual(var, module);
        }
        [TestMethod]
        public void TestModuleZP()// Проверка модуля комплексного числа, где вещественное = 0, а мнимое > 0
        {
            Complex a = new Complex();
            a.Init(0, 2);
            double module = a.Modul();
            int var = 2;
            Assert.AreEqual(var, module);
        }
        [TestMethod]
        public void TestModuleNN() // Проверка модуля комплексного числа, где вещественное и мнимое < 0
        {
            Complex a = new Complex();
            a.Init(-2, -1);
            double module = a.Modul();
            double var = Math.Sqrt(5);
            Assert.AreEqual(var, module);
        }
        [TestMethod]
        public void TestModuleZZ() // Проверка модуля комплексного числа, где вещественное и мнимое = 0
        {
            Complex a = new Complex();
            a.Init(0, 0);
            double module = a.Modul();
            int var = 0;
            Assert.AreEqual(var, module);
        }
    }
    [TestClass]
    public class UnitTest_Summ
    {
        [TestMethod]
        public void TestSummPP() // Проверка сложения комплексных чисел, где вещественное и мнимое > 0
        {
            Complex a = new Complex();
            Complex b = new Complex();
            Complex c = new Complex();
            Complex d = new Complex();
            a.Init(1, 1);
            b.Init(2, 2);
            c = c.Add(a, a);
            Assert.AreEqual(b.mc, c.mc);
            Assert.AreEqual(b.ic, c.ic);
        }

        [TestMethod]
        public void TestSummNN() // Проверка сложения комплексных чисел, где вещественное и мнимое < 0
        {
            Complex a = new Complex();
            Complex b = new Complex();
            Complex c = new Complex();
            Complex d = new Complex();
            a.Init(-1, -1);
            b.Init(-2, -2);
            c = c.Add(a, a);
            Assert.AreEqual(b.mc, c.mc);
            Assert.AreEqual(b.ic, c.ic);
        }

        [TestMethod]
        public void TestSummNP()// Проверка сложения комплексных чисел, где вещественное <0, мнимое > 0
        {
            Complex a = new Complex();
            Complex b = new Complex();
            Complex c = new Complex();
            Complex d = new Complex();
            a.Init(-1, 1);
            b.Init(-2, 2);
            c = c.Add(a, a);
            Assert.AreEqual(b.mc, c.mc);
            Assert.AreEqual(b.ic, c.ic);
        }

        [TestMethod]
        public void TestSummZZ()// Проверка сложения комплексных чисел, где вещественное и мнимое = 0
        {
            Complex a = new Complex();
            Complex b = new Complex();
            Complex c = new Complex();
            Complex d = new Complex();
            a.Init(0, 0);
            b.Init(0, 0);
            c = c.Add(a, a);
            Assert.AreEqual(b.mc, c.mc);
            Assert.AreEqual(b.ic, c.ic);
        }

    }
}

