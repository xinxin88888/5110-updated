using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// ErrorModel will be responsible for Error Page
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    public class ErrorModel : PageModel
    {
        // Getter/Setter for RequestId
        public string RequestId { get; set; }

        // Getter/Setter for ShowRequestId
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Getter/Setter for Logger
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// ErrorModel constructor
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet function will look for a RequestId
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}