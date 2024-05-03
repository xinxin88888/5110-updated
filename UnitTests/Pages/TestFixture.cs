using System.IO;

using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// TextFixture is a necessary class for starting up unit tests
    /// </summary>
    [SetUpFixture]
    
    public class TestFixture
    {
        // Path to the Web Root
        public static string DataWebRootPath = "./wwwroot";

        // Path to the data folder for the content
        public static string DataContentRootPath = "./data/";

        // Test Database
        public static string DataTestFile = "products_test.json";

        // Production Database
        public static string DataProductionFile = "products.json";

        // Net version (change when .net has different version
        public static string NetVersion = "net7.0";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.

            // This will copy the test database to the new location for the production
            // database. The reason is because when the code starts it reacts to the 
            // production database (products.json). If we copy the test database so
            // it uses the production database name, then the unit tests will work on 
            // a static representation, so that it should pass. The production database
            // might be dynamic for instance.

            var DataWebPath = "../../../../src/bin/Debug/" + NetVersion + "/wwwroot/data";
            var DataUTDirectory = "wwwroot";
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Destination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }
            
            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            
            // Copy over all data files from old path to new path
            var filePaths = Directory.GetFiles(DataWebPath);
            foreach (var filename in filePaths)
            {
                string OriginalFilePathName = filename.ToString();
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }

        }

        /// <summary>
        /// RunAfterAnyTests will contain activities you do after each test
        /// </summary>
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}