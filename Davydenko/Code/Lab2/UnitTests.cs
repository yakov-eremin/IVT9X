using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectForTest;
using System;

namespace UnitTests
{
    [TestClass]
    public class ManagerTest
    {

        [TestMethod]
        public void FindMax_MaxPositive()//тест для метода FindMax при поиске в положительных
        {
            int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int expected = 11;//ожидаемое значение
            int actual = Manager.FindMax(mass);//действительное значение
            Assert.AreEqual(expected, actual);//сравнить и сделать вывод - прошёл/непрошёл
        }

        [TestMethod]
        public void FindMax_MaxNegative()// при поиске в отрицательных
        {
            int[] mass = { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11 };
            int expected = -1;
            int actual = Manager.FindMax(mass);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindMax_NullArray()//вывод ошибки при передачи пустого массива
        {
            int[] mass = null;
            int actual = Manager.FindMax(mass);
        }

        [TestMethod]
        public void Avarage_Test()//тест на поиск среднего
        {
            int[] mass = { 8, 10, 9, 10 };
            double excpected = 9.25;
            double actual = Manager.Avarage(mass);
            Assert.AreEqual(excpected, actual, 0.01);
        }
    }

    [TestClass]
    public class NewArrayTest//класс для тестирования класса массивов
    {
        NewArray arr; //создание объекта для тестов

        [TestInitialize]
        public void Initialize()
        {
            double[] mass = { 1, 2, -3.4, -5, 6, 7, -8, 0.9, 10.11 };
            arr = new NewArray(mass);
        }

        [TestMethod]
        public void SumTest()//метод для тестирвания суммы
        {
            double expected = 10.61;
            double actual = arr.Sum();
            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void InitTest()//метод для тестирования инициализвции из txt
        {
            string path = "C:/Users/Anton/source/repos/ProjectForTest/mass.txt";
            double[] expected = { 1, 10, 4.5, -8, -8.9, 0};
            arr.Init(path);
            double[] actual = arr.array;
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Init_NullPath()
        {
            string path = null;
            arr.Init(path);
        }
        [TestMethod]
        public void AddTest()//тестирование сложение двух эл класса
        {
            double[] mass = { 1, 10, 4.5, -8, -8.9, 0 };
            NewArray newArray = new NewArray(mass);
            double[] expected = { 2, 12, 1.1, -13, -2.9, 7, -8, 0.9, 10.11 };
            arr = arr.Add(newArray);
            double[] actual = arr.array;
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 0.01);
            }
        }
    }
    [TestClass]
    public class TypeArrayTests
    {
        [TestMethod]
        public void DefineType_Positive()//определение типа для положительного
        {
            double[] mass = { 1, 2, 3, 4 };
            int expected = 1;
            int actual = TypeArray.DefineType(mass);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DefineType_Negative()//определение типа для отрицательного
        {
            double[] mass = { -10, -8.9, -13 -0.001, -2 };
            int expected = -1;
            int actual = TypeArray.DefineType(mass);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DefineType_Combined()//определение типа для смешанного
        {
            double[] mass = { 2, 12, 1.1, -13, -2.9, 7, -8, 0.9, 10.11 };
            int expected = 0;
            int actual = TypeArray.DefineType(mass);
            Assert.AreEqual(expected, actual);
        }
    }
}
