using NUnit.Framework;
using NUnitTestProjectWithLogger.Helper.Logger;

namespace NUnitTestProjectWithLogger
{
    [TestFixture]
    public class Tests : InitializeTest
    {
        private Logger logger;

        [SetUp]
        public void Setup()
        {
            var testCaseName = TestContext.CurrentContext.Test.Name;
            logger = new Logger(testCaseName,folderPath);
        }

        [Test]
        public void Test1()
        {
            logger.Log("My First Log");
            Assert.Pass();
        }
    }
}