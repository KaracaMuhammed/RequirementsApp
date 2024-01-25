using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MK.RequirementsApp.BlazorUI.Interfaces;
using MK.RequirementsApp.Domain;
using System.Net.Http.Json;
using System.Text.Json;

namespace MK.RequirementsApp.BlazorUI.Services
{
    public class ProductService : IProductService
    {

        private HttpClient httpClient { get; set; }
        private List<string> baseUrls = new List<string>() { "https://192.168.0.238:5001" /*, "https://localhost:5001", "https://192.168.0.241:5001"*/  };

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    var apiUrl = $"{baseUrl}/api/products";
                    var response = await httpClient.GetStringAsync(apiUrl);

                    //Console.WriteLine(response);

                    var products = JsonSerializer.Deserialize<List<Product>>(response, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    allProducts.AddRange(products);
                    break;
                }
                catch (HttpRequestException innerEx)
                {
                    //Console.WriteLine($"Error fetching products from {baseUrl}: {innerEx.Message}");
                }
            }

            allProducts.Reverse();
            return allProducts;
        }


        public async Task UpdateProductStatus(int productId)
        {
            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    // Make an API request to update the product status
                    var apiUrl = $"{baseUrl}/api/products/update/{productId}";
                    var response = await httpClient.PutAsync(apiUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response);
                        // Handle successful update, e.g., refresh the product list
                        // Parse the response to get the updated product
                        var updatedProductJson = await response.Content.ReadAsStringAsync();
                        var updatedProduct = JsonSerializer.Deserialize<Product>(updatedProductJson, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        break;
                    }
                    else
                    {
                        // Handle update failure
                        //Console.WriteLine($"Failed to update product with ID {productId}. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException innerEx)
                {
                    //Console.WriteLine($"Error updating product status at {baseUrl}: {innerEx.Message}");
                }
            }
        }

        public async Task CreateProduct(ProductDTO product)
        {
            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    var apiUrl = $"{baseUrl}/api/products";
                    var response = await httpClient.PostAsJsonAsync(apiUrl, product);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response);

                        var createdProductJson = await response.Content.ReadAsStringAsync();
                        var createdProduct = JsonSerializer.Deserialize<ProductDTO>(createdProductJson, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        break;
                    }
                    else
                    {
                        // Handle creation failure
                        // Console.WriteLine($"Failed to create product. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException innerEx)
                {
                    // Console.WriteLine($"Error creating product at {baseUrl}: {innerEx.Message}");
                }
            }
        }

        public async Task DeleteProduct(int productId)
        {
            foreach (var baseUrl in baseUrls)
            {
                try
                {
                    // Make an API request to delete the product
                    var apiUrl = $"{baseUrl}/api/products/delete/{productId}";
                    var response = await httpClient.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response);
                        break;
                    }
                    else
                    {
                        // Console.WriteLine($"Failed to delete product with ID {productId}. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException innerEx)
                {
                    // Console.WriteLine($"Error deleting product at {baseUrl}: {innerEx.Message}");
                }
            }
        }


    }
}
