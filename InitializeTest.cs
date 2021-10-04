using NUnit.Framework;
using NUnitTestProjectWithLogger.Helper.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProjectWithLogger
{
    [SetUpFixture]
    public class InitializeTest
    {
        public string folderPath = Logger.SetFolderPath();
        [OneTimeSetUp]
        public void BeforeTest()
        {
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            Logger logger = new Logger(folderPath);
            logger.CombineMultipleFilesIntoSingleFile();
        }
    }
}
