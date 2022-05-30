using NUnit.Framework;
using lab4;
using System.IO;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestStringVopros1()
        {
            StreamReader sr = new StreamReader(@"C:\lab4.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros1("a");

        }
        [Test]
        public void TestStringVopros2()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros2("c");
            string x = "���������! �� �������� 2 000 ������! ";
            Assert.AreEqual(x, check);

        }
        [Test]
        public void TestStringVopros3()
        {
            StreamReader sr = new StreamReader(@"C:\lab4.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros3("b");

        }
        [Test]
        public void TestStringVopros4()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros4("d");
            string x = "���������! �� �������� 10 000 ������! ";
            Assert.AreEqual(x, check);

        }
        [Test]
        public void TestStringVopros5()
        {
            StreamReader sr = new StreamReader(@"C:\lab4.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros5("a");
        }
        [Test]
        public void TestStringVopros6()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros6("b");
            string x = "���������! �� �������� 50 000 ������! ";
            Assert.AreEqual(x, check);
        }
        [Test]
        public void TestStringVopros7()
        {
            StreamReader sr = new StreamReader(@"C:\lab4.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros7("d");

        }
        [Test]
        public void TestStringVopros8()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros8("c");
            string x = "���������! �� �������� 200 000 ������! ";
            Assert.AreEqual(x, check);

        }
        [Test]
        public void TestStringVopros9()
        {
            StreamReader sr = new StreamReader(@"C:\lab4.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros9("a");

        }
        [Test]
        public void TestStringVopros10()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.vopros10("b");
            string x = "�����������!!! �� �������� 1 000 000 ������! ";
            Assert.AreEqual(x, check);

        }
    }
}
