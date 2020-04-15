using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public class FakeProductsService : IProductsService
    {
        private readonly PriceHistoriesDTO[] _priceHistories =
        {
            new PriceHistoriesDTO { Id = 31, Price = 2.58, EffectiveFrom = DateTime.Now, ProductId = 5},
            new PriceHistoriesDTO { Id = 32, Price = 5.58, EffectiveFrom = DateTime.Now, ProductId = 3},
        };

        public Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories()
        {
            var priceHistories = _priceHistories.AsEnumerable();
            return Task.FromResult(priceHistories);
        }

        public Task<HttpResponseMessage> PushPrice(PriceHistoriesDTO product)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
