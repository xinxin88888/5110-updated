
using System.Linq;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;


namespace UnitTests.Services.TestJsonFileProductService
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        /// <summary>
        /// REST Get Products data
        /// POST a valid rating
        /// Test that the last data that was added was added correctly
        /// </summary>
        [Test]
        public void AddRating_Valid_ProductId_Return_true()
        {
            // Arrange

            // Create Dummy Record with no prior Ratings
            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            // Store the result of the AddRating method (which is being tested)
            bool validAdd = TestHelper.ProductService.AddRating(data.Id, 0);

            // Assert
            Assert.AreEqual(true, validAdd);

            // Reset
            // Delete Dummy Record
        }

        /// <summary>
        /// REST POST data that doesn't fit the constraints defined in function
        /// Test if it Adds
        /// Returns False because it wont add
        /// </summary>
        [Test]
        public void AddRating_Invalid_Product_ID_Not_Present_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating("1000", 5);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get result of false ID entered data
        /// Checks if the result equals the added data
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_ID_Null_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST Gets First Node of original data
        /// Caches the length of how many votes were made
        /// POST a new rating of 5 stars
        /// Gets first node of new data
        /// Checks origional data length against the new data length +1
        /// Checks if last data point was the one that was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            // Store the original Rating list length
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            // Get the updated First data item
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// REST get original data list
        /// Post rating to the data where number of stars are invalid
        /// Resturns false for invalid data point
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_more_5_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original ratings
        /// POST a rating against the constraint <=0
        /// Compares rating to see if added corrctly
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_less_than_0_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, -2);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original data
        /// Cache length of data
        /// POST new valid data point
        /// GET new data
        /// Test if equal count is original + 1, and new data should be equal
        /// Test if the correct valid data point was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_greater_than_0_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Store the original Rating list length for comparison later
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 1);
            // Get the updated First data item for comparison
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(1, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        #region CreateDummyProduct
        /// <summary>
        /// This will test our Service "JsonFileProductService" routines
        /// Will create a dummy product, and also test for delete when we set it
        /// back
        /// </summary>
        [Test]
        public void Create_Valid_ProductId_Return_true()
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

            // Act
            var data = TestHelper.ProductService.CreateData(dummyData);

            // Assert
            Assert.IsNotNull(data);
            Assert.AreEqual(true, TestHelper.ProductService.GetAllData().Any(x => x.Id == dummyData.Id));

            // Reset
            TestHelper.ProductService.DeleteData(dummyData.Id);

        }

        #endregion CreateDummyRecord

        #region DeleteDummyProduct
        /// <summary>
        /// This will test our Service "JsonFileProductService" routines
        /// Will create a dummy product, and also test for delete when we set it
        /// back
        /// </summary>
        [Test]
        public void Delete_Valid_ProductId_Return_true()
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

            // Act
            TestHelper.ProductService.CreateData(dummyData);

            // Assert (Create, Delete, Do not find record)
            Assert.AreEqual(true, TestHelper.ProductService.GetAllData().Any(x => x.Id == dummyData.Id));
            TestHelper.ProductService.DeleteData(dummyData.Id);
            Assert.AreEqual(false, TestHelper.ProductService.GetAllData().Any(x => x.Id == dummyData.Id));
        }

        #endregion DeleteDummyRecord


    }
}