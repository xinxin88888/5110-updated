using System.Linq;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;



namespace UnitTests.Pages.Index
{
    /// <summary>
    /// Provides unit testing for the Index page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        // Declare the model of the Index page to be used in unit tests
        public static IndexModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock index page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            // Logs where the name is derived from for the mocked IndexModel
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        /// <summary>
        /// Tests that loading the index page returns a non-empty list of products
        /// </summary>
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Are there any in existence?
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}