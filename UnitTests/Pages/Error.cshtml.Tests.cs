using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// Provides unit testing for the Error page
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup
        // Declare the model of the Error page to be used in unit tests
        public static ErrorModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock error page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            // Logs where the category name is derived from for the mocked ErrorMoel
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {
                // Holds the dummy PageContext from testHelper
                PageContext = TestHelper.PageContext,
                // Holds the dummy tempData from testHelper
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        /// <summary>
        /// Tests that starting a valid activity then going to the Error page correctly sets the RequestId for the Error page as the
        /// activity Id
        /// </summary>
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Creates a valid activity to test the pageModel with
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
        }

        [Test]
        /// <summary>
        /// Tests that having an invalid activity then going to the Error page correctly sets the RequestId for the Error page as "trace"
        /// while maintaining a valid state
        /// </summary>
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);
        }
        #endregion OnGet
    }
}