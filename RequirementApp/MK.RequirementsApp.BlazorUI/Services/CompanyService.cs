using MK.RequirementsApp.BlazorUI.Interfaces;
using MK.RequirementsApp.Domain;
using System.Net.Http;
using System.Text.Json;

namespace MK.RequirementsApp.BlazorUI.Services
{
    public class CompanyService : ICompanyService
    {

        private HttpClient httpClient { get; set; }
        private List<string> baseUrls = new List<string>() { "https://localhost:5001" /*"https://192.168.0.238:5001", "https://localhost:5001", "https://192.168.0.241:5001"*/ };

        public CompanyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();

            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    var apiUrl = $"{baseUrl}/api/companies";
                    var response = await httpClient.GetStringAsync(apiUrl);
                    companies = JsonSerializer.Deserialize<List<Company>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    break;
                }
                catch (HttpRequestException innerEx)
                {
                    Console.WriteLine($"Error fetching products from {baseUrl}: {innerEx.Message}");
                }
            }

            return companies;
        }

    }
}
