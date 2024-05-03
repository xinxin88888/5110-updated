using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Controllers;


namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit tests for ProductsController class
    /// </summary>
    public class ProductsControllerTest
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


        #region
        /// <summary>
        /// Creates a default datapoint of ProductServices
        /// Creates a new datapoint of the a ProductsController with datapoint
        /// Gets the whole datapoint
        /// Tests if Equal
        /// </summary>
        [Test]
        public void get_AllData_Present_Should_Return_True()
        {
            //arrange
            //Create new default ProductService datapoint

            //Act
            //store datapoint as a ProductController datapoint
            var newData = new ProductsController(TestHelper.ProductService).Get().First();

            var response = TestHelper.ProductService.GetAllData().First();

            //Assert
            Assert.AreEqual(newData.Id, response.Id);
        }
        #endregion

        #region
        /// <summary>
        /// Creates a default datapoint of ProductServices
        /// Creates a new datapoint of the a ProductsController with datapoint
        /// Gets the whole datapoint
        /// Tests if Added dataPoint equals the created one
        /// </summary>
        [Test]
        public void Patch_AddValid_Rating_Should_Return_True()
        {
            //arrange
            //Create new default ProductService datapoint

            //Act
            //store datapoint as a ProductController datapoint
            var newData = new ProductsController(TestHelper.ProductService);
            //Create a newRating datapoint to "Patch to theDataController"
            var newRating = new ProductsController.RatingRequest();
            {
                newRating.ProductId = newData.ProductService.GetAllData().Last().Id;
                newRating.Rating = 5;
            }

            //Act
            newData.Patch(newRating);

            //Assert
            Assert.AreEqual(newData.ProductService.GetAllData().Last().Id, newRating.ProductId);
        }
        #endregion
    }
}