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

        [TestMethod]
        public void Count_files_test2()
        {
            Directory.CreateDirectory("tmp");
            File.Create("tmp/1.txt").Close();
            File.Create("tmp/2.txt").Close();
            File.Create("tmp/3.ini").Close();
            File.Create("tmp/4.txt").Close();
            int expected = 3;
            int result = Remover.CountFiles("tmp", "*.txt");
            Directory.Delete("tmp", true);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void Delete_files_test()
        {
            Directory.CreateDirectory("tmp2");
            File.Create("tmp2/a.txt").Close();
            File.Create("tmp2/b.pdf").Close();
            Remover.DeleteFiles("tmp2", "*.txt");
            bool result = (!File.Exists("tmp2/a.txt") && File.Exists("tmp2/b.pdf"));
            Directory.Delete("tmp2", true);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_files_test2()
        {
            Directory.CreateDirectory("tmp2");
            File.Create("tmp2/a.txt").Close();
            File.Create("tmp2/b.txt").Close();
            Remover.DeleteFiles("tmp2", "*.txt");
            bool result = (!File.Exists("tmp2/a.txt") && !File.Exists("tmp2/b.txt"));
            Directory.Delete("tmp2", true);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Count_files_date_test()
        {
            Directory.CreateDirectory("tmp3");
            File.Create("tmp3/1.txt").Close();
            File.Create("tmp3/2.txt").Close();
            File.SetCreationTime("tmp3/1.txt", new System.DateTime(2020, 01, 01));
            File.SetCreationTime("tmp3/2.txt", new System.DateTime(2022, 01, 01));
            int expected = 1;
            int result = Remover.CountFilesByDate("tmp3", new System.DateTime(2021, 01, 01), new System.DateTime(2022, 12, 31));
            Directory.Delete("tmp3", true);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Count_files_date_test2()
        {
            Directory.CreateDirectory("tmp3");
            File.Create("tmp3/1.txt").Close();
            File.Create("tmp3/2.txt").Close();
            File.Create("tmp3/3.txt").Close();
            File.SetCreationTime("tmp3/1.txt", new System.DateTime(2020, 01, 01));
            File.SetCreationTime("tmp3/2.txt", new System.DateTime(2022, 01, 01));
            File.SetCreationTime("tmp3/3.txt", new System.DateTime(2021, 02, 02));
            int expected = 2;
            int result = Remover.CountFilesByDate("tmp3", new System.DateTime(2021, 01, 01), new System.DateTime(2022, 12, 31));
            Directory.Delete("tmp3", true);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Delete_files_date_test()
        {
            Directory.CreateDirectory("tmp4");
            File.Create("tmp4/a.txt").Close();
            File.Create("tmp4/b.txt").Close();
            File.SetCreationTime("tmp4/a.txt", new System.DateTime(2020, 01, 01));
            File.SetCreationTime("tmp4/b.txt", new System.DateTime(2022, 01, 01));
            Remover.DeleteFilesByDate("tmp4", new System.DateTime(2000, 01, 01), new System.DateTime(2020, 03, 03));
            bool result = (!File.Exists("tmp4/a.txt") && File.Exists("tmp4/b.txt"));
            Directory.Delete("tmp4", true);
            Assert.IsTrue(result);
        }
    }
}
