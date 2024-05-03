using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// Provides unit testing for the Create page
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        // Declare the model of the Create page to be used in unit tests
        public static CreateModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock Create page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Test that the dummy data is initialized
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_New_ProductId()
        {
            // Arrange

            // Act
            pageModel.OnGet();// Should return an ID

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(false, pageModel.Product.Id == "");
        }
        #endregion OnGet

        #region OnPost
        /// <summary>
        /// Test that the dummy data is initialized
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Add_Product()
        {
            // Arrange
            // Create a dummy variable to insert. We will only put 3 fields (Good Enough)
            var dummyData = new ProductModel
            {

                Id = "mike-test",
                Title = "Scarecrow-costume",
                Description = "From Wizard of OZ",
                Url = "https://solarsystem.nasa.gov/planets/venus/overview/",
                Image = "https://solarsystem.nasa.gov/system/news_items/list_view_images/1519_688_Venus_list.jpg"
            };
            pageModel.Product = dummyData;

            // Act (Post the insert)
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Can we read it?
            Assert.AreEqual(true, pageModel.ProductService.GetAllData().Any(x => x.Id == dummyData.Id));

            // Reset it back by doing a Delete
            pageModel.ProductService.DeleteData(dummyData.Id);
        }

        /// <summary>
        /// Invalid Model then return same page
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_Should_Return_Page()
        {
            // Arrange
            // Create a dummy variable to insert
            var dummyData = new ProductModel
            {
                Id = "v",
                Title = "v",
                Description = "2nd planet",
                Url = "https://solarsystem.nasa.gov/planets/venus/overview/",
                Image = "https://solarsystem.nasa.gov/system/news_items/list_view_images/1519_688_Venus_list.jpg"
            };

            pageModel.Product = dummyData;

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            // Store the ActionResult of the post
            var result = pageModel.OnPost() as ActionResult;
            // Store whether the ModelState is valid for later assert
            var stateIsValid = pageModel.ModelState.IsValid;

            // Reset

            // Assert
            Assert.AreEqual(false, stateIsValid);
        }
        #endregion OnPost
    }
}
