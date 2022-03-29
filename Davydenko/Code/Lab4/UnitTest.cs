using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;

namespace TestProject
{
    [TestClass]
    public class LibraryTest
    {
        Library library;

        [TestInitialize]
        public void LibraryInitializeTest()
        {
            library = new Library();
            Assert.IsNotNull(library);
        }

        [TestMethod]
        public void ReturnAnswerTest()
        {
            string _answer = "Answer";
            Assert.AreEqual(library._answer, _answer);             
        }
        [TestMethod]
        public void ReturnQuestionTest()
        {
            string _questions = "Question";
            Assert.AreEqual(library._question, _questions);
        }
    }
}