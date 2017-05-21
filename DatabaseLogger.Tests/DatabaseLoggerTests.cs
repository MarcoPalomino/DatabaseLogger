using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseLogger.Tests
{
    [TestClass]
    public class DatabaseLoggerTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerifyConnectionStringIsObtained()
        {
            //Arrange
            var logger = new Logger();

            //Act
            var connectionString = logger.GetConnectionString();

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(connectionString));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerifyDBLogWasSuccessfullySaved()
        {
            //Arrange
            var logger = new Logger();
            string logType = "W";
            string logMessage = "log Message";

            //Act
            bool isProcessedSuccessfully;
            isProcessedSuccessfully = logger.DoLog(logType, logMessage);

            //Assert
            Assert.IsTrue(isProcessedSuccessfully);
        }
    }
}