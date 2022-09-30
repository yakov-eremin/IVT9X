using lr4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace lr4test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Count_files_test()
        {
            Directory.CreateDirectory("tmp");
            File.Create("tmp/1.txt").Close();
            File.Create("tmp/2.txt").Close();
            File.Create("tmp/3.ini").Close();
            int expected = 2;
            int result = Remover.CountFiles("tmp", "*.txt");
            Directory.Delete("tmp", true);
            Assert.AreEqual(expected, result);
        }
    }
}
