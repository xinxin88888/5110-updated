using NUnit.Framework;
using ContosoCrafts.WebSite.Models;


namespace UnitTests.Models
{
    /// <summary>
    /// Comment Model Unit test
    /// </summary>
    public class CommentModelTest
    {
        #region TestSetup
        /// <summary>
        /// Test Setup
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion

        #region CommentID
        /// <summary>
        /// New Comment ID validation
        /// </summary>
        [Test]
        public void New_Comment_ID_Test_Should_Return_True()
        {
            //Arrange
            var newData = new CommentModel();

            //Act
            newData.Id = "1234";

            //Assert
            Assert.AreEqual("1234", newData.Id);
        }
        #endregion

        #region Comment
        /// <summary>
        /// New Comment validation
        /// </summary>
        [Test]
        public void New_Comment_Test_Should_Return_True()
        {
            //Arrange
            var newData = new CommentModel();

            //Act
            newData.Comment = "Testing";

            //Assert
            Assert.AreEqual("Testing", newData.Comment);
        }
        #endregion
    }
}
