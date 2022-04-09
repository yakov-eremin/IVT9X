using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp4;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class CircleTests
    {
        [TestInitialize]
        public void CircleInit_Test()
        {
            Circle circle = new Circle(2.0, 3.0, 10.0);
        }

        [TestMethod]
        public void GetDistance_Test()
        {
            // Arrange
            Circle circle = new Circle(2.0, 3.0, 10.0);

            // Act
            double result = circle.GetDistance();

            // Assert
            Assert.AreEqual(3.61, result, 0.01);
        }

        [TestMethod]
        public void GetArea_Test()
        {
            // Arrange
            Circle circle = new Circle(2.0, 3.0, 10.0);

            // Act
            double result = circle.GetArea();

            // Assert
            Assert.AreEqual(314.16, result, 0.01);
        }

        [TestMethod]
        public void GetNearestPoint_Test()
        {
            // Arrange
            Circle circle = new Circle(2.0, 3.0, 10.0);

            // Act
            double result = circle.GetNearestPointDistance();

            // Assert
            Assert.AreEqual(6.39, result, 0.01);
        }

        [TestMethod]
        public void SumCircles_Test()
        {
            // Arrange
            Circle a = new Circle(1.0, 2.0, 3.0);
            Circle b = new Circle(4.0, 5.0, 6.0);
            Circle sum = a.Add(b);
            double[] expected = { 2.5, 3.5, 9.0 };

            // Act
            double[] result = { sum.GetX(), sum.GetY(), sum.GetRadius() };

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class CylinderTests
    {
        [TestInitialize]
        public void CylinderInit_Test()
        {
            Cylinder cylinder = new Cylinder(1.0, 2.0, 3.0, 4.0);
        }

        [TestMethod]
        public void GetDistance_Test()
        {
            // Arrange
            Cylinder cylinder = new Cylinder(1.0, 2.0, 3.0, 4.0);

            // Act
            double result = cylinder.GetDistance();

            // Assert
            Assert.AreEqual(2.69, result, 0.01);
        }

        [TestMethod]
        public void GetVolume_Test()
        {
            // Arrange
            Cylinder cylinder = new Cylinder(1.0, 2.0, 3.0, 4.0);

            // Act
            double result = cylinder.GetVolume();

            // Assert
            Assert.AreEqual(150.80, result, 0.01);
        }

        [TestMethod]
        public void SumCylinders_Test()
        {
            // Arrange
            Cylinder a = new Cylinder(1.0, 2.0, 3.0, 4.0);
            Cylinder b = new Cylinder(5.0, 6.0, 7.0, 8.0);
            Cylinder sum = a.Add(b);
            double[] expected = { 3.0, 4.0, 10.0, 12.0 };

            // Act
            double[] result = { sum.GetX(), sum.GetY(), sum.GetHeight(), sum.GetRadius() };

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class StringLibraryTests
    {
        [TestMethod]
        public void GetMaxLengthString_Test()
        {
            // Arrange
            string[] array = new string[] { "a", "ab", "abc", "abcdef", "abcd" };

            // Act
            string result = StringLibrary.GetMaxLengthString(array);

            // Assert
            Assert.AreEqual("abcdef", result);
        }

        [TestMethod]
        public void GetMinLengthString_Test()
        {
            // Arrange
            string[] array = new string[] { "abcdefg", "abc", "cde", "kkkkkk", "abcd" };

            // Act
            string result = StringLibrary.GetMinLengthString(array);

            // Assert
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException_Test()
        {
            string[] array = null;
            StringLibrary.GetMaxLengthString(array);
        }
    }
}
