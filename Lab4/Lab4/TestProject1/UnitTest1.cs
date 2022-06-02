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

    }
}
