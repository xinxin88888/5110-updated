using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    public class ClassifyBreadModel : PageModel
    {
        private readonly MLService _mlService;

        public ClassifyBreadModel()
        {
            _mlService = new MLService();
        }

        [BindProperty]
        public IFormFile File { get; set; }

        public string Prediction { get; private set; }
        public string Error { get; private set; }

        public void OnPost()
        {
            if (File == null || File.Length == 0)
            {
                Error = "Please upload a file";
                return;
            }

            var filePath = Path.Combine(Path.GetTempPath(), File.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                File.CopyTo(stream);
            }

            var response = _mlService.InferImage(filePath);
            Prediction = JObject.Parse(response)["predictions"].ToString();
        }
    }
}
