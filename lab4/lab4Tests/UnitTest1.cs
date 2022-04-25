using NUnit.Framework;
using lab4;
namespace lab4Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void lab4Test1()
        {
            string select = "select * from [Friends]";
            Assert.NotNull(select);
        }
        [Test]
        public void lab4Test2()
        {
            string insert = "insert into friends (name, surname, date, year) values (N'', N'', '', '')";
            Requests requests = new Requests();
            Assert.NotNull(requests.Insert(insert));
        }
        [Test]
        public void lab4Test3()
        {
            string delete = "delete from friends where id=''";
            Requests requests = new Requests();
            Assert.NotNull(requests.Insert(delete));
        }
        [Test]
        public void lab4Test4()
        {
            Requests requests = new Requests();
            Assert.NotNull(requests.Exit());
        }
    }
}