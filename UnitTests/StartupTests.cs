using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

namespace UnitTests.Pages.Startup
{
    /// <summary>
    /// StartupTests class necessary for unit tests
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

        /// <summary>
        /// TestInitialize will initialize Tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// Startup class
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        /// <summary>
        /// Will configure tests
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region Configure
        /// <summary>
        /// Will test for Startup Configuration
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}