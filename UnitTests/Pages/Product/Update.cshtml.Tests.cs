using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Provides unit testing for the Update page
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        // Declare the model of the Update page to be used in unit tests
        public static UpdateModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock Update page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        /// <summary>
        /// Test that's loading the update page returns a non-empty list of products
        /// </summary>
        public void OnGet_Valid_Should_Return_Product()
        {
            // Arrange

            // Act
            pageModel.OnGet("mike-clown");
            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Amazon", pageModel.Product.Maker);

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();

        }


        [Test]
        /// <summary>
        /// Test that's loading the update page returns an invalid state
        /// </summary>
        public void OnGet_Valid_Should_Return_InvalidState()
        {
            // Arrange

            // Act
            pageModel.OnGet("mike-clown1");  // Should not find
            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);

            // Reset
            pageModel.ModelState.Clear();

        }
        #endregion OnGet

        #region OnPost
        [Test]
        /// <summary>
        /// Test that checks update functionality
        /// </summary>
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("mike-clown");
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            var originalMaker = pageModel.Product.Maker;

            // change Value to Microsoft  and update
            pageModel.Product.Maker = "Microsoft";
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert to see that post succeeeded
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            // Read it to see if it changed
            pageModel.OnGet("mike-clown");

            // Assertions to verify
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Microsoft", pageModel.Product.Maker);

            // Reset it back
            pageModel.Product.Maker = originalMaker;
            result = pageModel.OnPost() as RedirectToPageResult;
            // Assert to see that post succeeeded
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            // Reset 
            pageModel.ModelState.Clear();

        }

        [Test]
        /// <summary>
        /// Test that checks update functionality's error state
        /// </summary>
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            // Store the ActionResult of the post? TODO: better understand this line of code or ask professor
            var result = pageModel.OnPost() as ActionResult;
            // Store whether the ModelState is valid for later assert
            var stateIsValid = pageModel.ModelState.IsValid;

            // Assert
            Assert.AreEqual(false, stateIsValid);

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();
        }


        [Test]
        /// <summary>
        /// Test that's loading the update page returns a non-empty list of products
        /// </summary>
        public void OnPost_InValidID_Should_Return_Null()
        {
            // Arrange

            // Act
            pageModel.OnGet("mike-clown");
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            pageModel.Product.Id = "mike-clown2"; // post with an invalid id
            var result = pageModel.OnPost() as ActionResult;

            // Store whether the ModelState is valid for later assert
            var stateIsValid = pageModel.ModelState.IsValid;

            // Assert
            Assert.AreEqual(false, stateIsValid);

            // Reset
            // This should remove the error we added
            pageModel.ModelState.Clear();

        }
        #endregion OnPost
    }
}
