using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _client;

        public ProductsService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<ProductsDTO>> GetProducts()
        {
            var response = await _client.GetAsync("api/products/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<ProductsDTO> products = await response.Content.ReadAsAsync<IEnumerable<ProductsDTO>>();
            return products;
        }

        public async Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories()
        {
            var response = await _client.GetAsync("api/products/pricehostories/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<PriceHistoriesDTO> priceHistories = await response.Content.ReadAsAsync<IEnumerable<PriceHistoriesDTO>>();
            return priceHistories;
        }

        public async Task<PriceHistoriesDTO> PushPrice(PriceHistoriesDTO priceHistories)
        {
            var response = await _client.PostAsJsonAsync(
                "api/product/", priceHistories);
            response.EnsureSuccessStatusCode();

            return priceHistories;
        }
    }
}
