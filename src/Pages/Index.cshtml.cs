using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// IndexModel is the main class for displaying the Index Page (Home)
    /// </summary>
    public class IndexModel : PageModel
    {
        // Logger variable used for logging
        private readonly ILogger<IndexModel> _logger;

        // Constructor for IndexModel
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Getter/Setter for ProductService
        public JsonFileProductService ProductService { get; }
        
        // Getter/Setter for Products
        public IEnumerable<ProductModel> Products { get; private set; }

        // OnGet will get all the Data and render it in the Razor Page
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}