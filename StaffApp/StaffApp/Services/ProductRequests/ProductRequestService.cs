using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public class ProductRequestService : IProductRequest
    {
        private readonly HttpClient _client;

        public ProductRequestService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<ProductRequestDTO>> GetProductRequest()
        {
            var response = await _client.GetAsync("api/productrequests/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<ProductRequestDTO> productRequests = await response.Content.ReadAsAsync<IEnumerable<ProductRequestDTO>>();
            return productRequests;
        }

        public async Task<ProductRequestDTO> PushProductRequest(ProductRequestDTO productRequest)
        {
            var response = await _client.PostAsJsonAsync(
                "api/productrequest/", productRequest);
            response.EnsureSuccessStatusCode();

            return productRequest;
        }
    }
}
