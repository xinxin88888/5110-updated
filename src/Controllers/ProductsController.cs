using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]

    /// <summary>
    /// ProductsController will enable calls to be made directly to controller
    /// </summary>
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor of ProductsController
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        //variable of JsonFileProductService getter
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// varaiable of IEnumerable of ProductModel Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// Function of Addrating to a particular productId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// Class of Rating Request which has two properties: getter and setter of productId and Rating
        /// </summary>
        public class RatingRequest
        {
            //Getter and Setter of ProductId
            public string ProductId { get; set; }
            //Getter and Setter of Rating
            public int Rating { get; set; }
        }
    }
}