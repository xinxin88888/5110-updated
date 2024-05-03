using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            // Set the JSON FileName
            JsonFileName = Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); ;
         }


        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFileName { get; set; }

        public void SwitchJsonFileName()
        {
            // switch products.json with products_test.json
            JsonFileName = JsonFileName.Replace("products", "products_test");
        }

        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetAllData();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
 
            // TODO none of my data has no NULL Data in ratings, but want to fix this
            // when I start to create Unit Tests that can do inserts
            //if (data.Ratings == null)
            //{
            //    data.Ratings = new int[] { };
            //}

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public bool UpdateData(ProductModel data)
        {
            bool isValidUpdate = false;

            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                isValidUpdate = false;
                return isValidUpdate;
            }

            // Create a new product list without the changed object
            var newProductList = products.Where(x => x.Id != data.Id);
            newProductList = newProductList.Append(data);

            // Store it back in Json File
            SaveData(newProductList);

            isValidUpdate = true;
            return isValidUpdate;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData(ProductModel data)
        {

            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            // return the data
            return data;

        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            //retrieve data where ID value doesn't match the deleted ID value
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            //save the new dataset
            SaveData(newDataSet);

            //return new dataset without deleted ID
            return data;
        }
    }
}