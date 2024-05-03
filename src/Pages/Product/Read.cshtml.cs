using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                this.ModelState.AddModelError("bogus", "bogus error");
                return RedirectToPage("./Index"); // Probably should be an error message
            }

            return Page();
        }
    }
}