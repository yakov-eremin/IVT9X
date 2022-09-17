using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA_Lab4_Form;
namespace QA_Lab4_Tests
{
    [TestClass]
    public class BirthdayClass
    {
        [TestMethod]
        public void BirthdayCreation()
        {
            Birthday birthday = new Birthday();
            Assert.IsNotNull(birthday);
        }
    }
}