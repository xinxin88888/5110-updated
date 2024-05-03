using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Enums
{
    /// <summary>
    /// Class to provide unit testing of ProductTypeEnum.cs
    /// </summary>
    public class ProductTypeEnumTests
    {
        #region TestSetup
        /// <summary>
        /// Test Setup
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region StaticMethodsTests
        [Test]
        /// <summary>
        /// Test that checks functionality of GetName
        /// </summary>
        public void Valid_Enum_Should_Return_Correct_Name()
        {
            // Arrange
            ProductTypeEnum testEnum = ProductTypeEnum.Kids;

            // Act

            // Assert
            Assert.AreEqual("Kids", testEnum.ToString());
        }
        #endregion StaticMethodTests
    }
}