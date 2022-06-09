using Lab4;
using NUnit.Framework;
using System.IO;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckStringTest()
        {
            CheckString check = new CheckString();
            Assert.IsNotNull(check);
        }

        [Test]
        public void TestStringBack1()
        {
            StreamReader sr = new StreamReader(@"D:\therapist.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.back(20, "1");
            while ((line = sr.ReadLine()) != null)
            {
                string[] text = line.Split('*');
                Assert.AreEqual(text[1], check);
            }
        }


        [Test]
        public void TestStringBack2()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.back(9, "3");
            string x = "Мазь Индометацин на пораженный участок 3-4 раза в сутки. ";
            Assert.AreEqual(x, check);
        }
        [Test]
        public void TestStringHead1()
        {
            StreamReader sr = new StreamReader(@"D:\therapist.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.head(13, "1");
            while ((line = sr.ReadLine()) != null)
            {
                string[] text = line.Split('*');
                Assert.AreEqual(text[6], check);
            }
        }
        [Test]
        public void TestStringHead2()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.head(8, "2");
            string x = "Таблетки Но-шпа 40 г 1-2 раза в сутки. ";
            Assert.AreEqual(x, check);
        }
        [Test]
        public void TestStringLeg1()
        {
            StreamReader sr = new StreamReader(@"D:\therapist.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.leg(15, "2");
            while ((line = sr.ReadLine()) != null)
            {
                string[] text = line.Split('*');
                Assert.AreEqual(text[11], check);
            }
        }
        [Test]
        public void TestStringLeg2()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.leg(24, "3");
            string x = "Мазь Диклофенак 2 раза в сутки. ";
            Assert.AreEqual(x, check);
        }
        [Test]
        public void TestStringArm1()
        {
            StreamReader sr = new StreamReader(@"D:\therapist.txt");
            string line;
            CheckString checkstring = new CheckString();
            string check = checkstring.arm(55, "1");
            while ((line = sr.ReadLine()) != null)
            {
                string[] text = line.Split('*');
                Assert.AreEqual(text[9], check);
            }
        }
        [Test]
        public void TestStringArm2()
        {
            CheckString checkstring = new CheckString();
            string check = checkstring.arm(9, "2");
            string x = "После лечения Анальгин максимальная суточная доза - 2 таблетки в день. ";
            Assert.AreEqual(x, check);
        }
        [Test]
        public void TestStringBellyrm1()
        {
            CheckString check = new CheckString();
            string a = "qwerty123";
            Assert.AreEqual(a, check.belly());
        }
        [Test]
        public void TestStringBellyrm2()
        {
            CheckString check = new CheckString();
            string a = "qwerty123";
            Assert.AreEqual(a, check.belly());
        }


    }

}
