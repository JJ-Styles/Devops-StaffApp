using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public class ProductRequestService : StaffAppServices, IProductRequestsService
    {
        public ProductRequestService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public ProductRequestService() : base()
        {
        }

        public async Task<IEnumerable<ProductRequestProductsDTO>> GetProductRequestProducts()
        {
            var response = await GetClient().GetAsync("api/productRequest/products");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<ProductRequestProductsDTO> products = await response.Content.ReadAsAsync<IEnumerable<ProductRequestProductsDTO>>();
            return products;
        }

        public async Task<HttpResponseMessage> PushProductRequest(ProductRequestDTO productRequest)
        {
            return await GetClient().PostAsJsonAsync("api/productrequest/", productRequest);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var ProductRequest = new ProductRequestDTO();
            if (!ProductRequestDTO.ReferenceEquals(data.GetType(), ProductRequest))
            {
                return null;
            }
            ProductRequest = (ProductRequestDTO)nameof(data).Clone();
            return await PushProductRequest(ProductRequest);
        }
    }
}
