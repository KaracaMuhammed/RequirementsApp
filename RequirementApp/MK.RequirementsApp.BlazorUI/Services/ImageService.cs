using MK.RequirementsApp.BlazorUI.Interfaces;
using MK.RequirementsApp.Domain;
using System.Text.Json;

namespace MK.RequirementsApp.BlazorUI.Services
{
    public class ImageService : IImageService
    {

        private HttpClient httpClient { get; set; }
        private List<string> baseUrls = new List<string>() { "http://84.198.116.171:5000" /*"https://192.168.0.238:5001", "https://localhost:5001", "https://192.168.0.241:5001"*/ };

        public ImageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ImageDTO>> GetAllImages()
        {
            List<ImageDTO> images = new List<ImageDTO>();

            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    var apiUrl = $"{baseUrl}/api/images";
                    var response = await httpClient.GetStringAsync(apiUrl);
                    images = JsonSerializer.Deserialize<List<ImageDTO>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    break;
                }
                catch (HttpRequestException innerEx)
                {
                    Console.WriteLine($"Error fetching products from {baseUrl}: {innerEx.Message}");
                }
            }

            return images;
        }

        public async Task<List<ImageDTO>> GetActiveImages()
        {
            var images = new List<ImageDTO>();
            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    var apiUrl = $"{baseUrl}/api/images/active";
                    var response = await httpClient.GetStringAsync(apiUrl);
                    images = JsonSerializer.Deserialize<List<ImageDTO>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    break;
                }
                catch (HttpRequestException innerEx)
                {
                    Console.WriteLine($"Error fetching products from {baseUrl}: {innerEx.Message}");
                }
            }

            return images;
        }

    }
}
