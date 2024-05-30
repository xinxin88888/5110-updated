using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ContosoCrafts.WebSite.Controllers
{
    public class MLService
    {
        private readonly string _apiKey = "YOUR_API_KEY"; // Replace with your actual API key
        private readonly string _modelEndpoint = "bread-bnnvr/3"; // Model endpoint

        public string InferImage(string filePath)
        {
            byte[] imageArray = File.ReadAllBytes(filePath);
            string encoded = Convert.ToBase64String(imageArray);
            byte[] data = Encoding.ASCII.GetBytes(encoded);

            string uploadUrl = $"https://detect.roboflow.com/{_modelEndpoint}?api_key={_apiKey}&name={Path.GetFileName(filePath)}";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            WebRequest request = WebRequest.Create(uploadUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
