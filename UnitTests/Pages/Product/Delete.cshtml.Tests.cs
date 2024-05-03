
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Provides unit testing for the Update page
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        // Declare the model of the Update page to be used in unit tests
        public static DeleteModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock Update page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
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
            // Grab the first item for testing purposes
            var data = TestHelper.ProductService.GetAllData().First();


            // Act
            pageModel.OnGet(data.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, data.Id == pageModel.Product.Id);
        }
        #endregion OnGet

        #region OnPost
        /// <summary>
        /// valid data then return products
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // Create dummy data to insert
            var dummyData = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Dummy Test Data",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData(dummyData);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }
        #endregion OnPost
    }
}