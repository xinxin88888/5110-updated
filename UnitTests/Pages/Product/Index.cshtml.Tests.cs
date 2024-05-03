using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing for Index Tests
    /// </summary>
    public class IndexTests
    {
        // Database MiddleTier
        #region TestSetup
        public static IndexModel pageModel;
        /// <summary>
        /// Initialize of Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup
        /// <summary>
        /// Checking whether product user want is there in result or not.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert 
            // How many are there?
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Are there any in existence?
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}