using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public class ProductsService : StaffAppServices, IProductsService
    {
        public ProductsService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public ProductsService() : base()
        {
        }

        public async Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories()
        {
            var response = await GetClient().GetAsync("api/products/pricehostories/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<PriceHistoriesDTO> priceHistories = await response.Content.ReadAsAsync<IEnumerable<PriceHistoriesDTO>>();
            return priceHistories;
        }

        public async Task<HttpResponseMessage> PushPrice(PriceHistoriesDTO priceHistories)
        {
            return await GetClient().PostAsJsonAsync("api/product/", priceHistories);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var price = new PriceHistoriesDTO();
            if (!ProductsDTO.ReferenceEquals(data.GetType(), price))
            {
                return null;
            }
            price = (PriceHistoriesDTO)nameof(data).Clone();
            return await PushPrice(price);
        }
    }
}
