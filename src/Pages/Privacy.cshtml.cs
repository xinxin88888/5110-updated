using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// PrivacyModel used for Privacy Page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Logger variable
        private readonly ILogger<PrivacyModel> _logger;

        // Constructor that accepts logger as input
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet will essentially do nothing 
        /// </summary>
        public void OnGet()
        {
        }
    }
}
