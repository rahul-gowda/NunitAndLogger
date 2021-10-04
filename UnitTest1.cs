using NUnit.Framework;
using NUnitTestProjectWithLogger.Helper.Logger;

namespace NUnitTestProjectWithLogger
{
    [TestFixture]
    public class AnotherTest : InitializeTest
    {
        private Logger logger;

        [SetUp]
        public void Setup()
        {
            var testCaseName = TestContext.CurrentContext.Test.Name;
            logger = new Logger(testCaseName, folderPath);
        }

        [Test]
        public void Test2()
        {
            logger.Log("My Log from AnotherTest");
            Assert.Pass();
        }
    }
}