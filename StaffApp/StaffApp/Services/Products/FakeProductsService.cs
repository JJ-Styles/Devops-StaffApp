using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public class FakeProductsService : IProductsService
    {
        private readonly ProductsDTO[] _products =
        {
            new ProductsDTO { id = 64, Name = "Magical Unicorn", Description ="Large Magical Unicorn", StockLevel = 24},
            new ProductsDTO { id = 65, Name = "Magical Dragon", Description ="Large Magical Dragon", StockLevel = 52},
            new ProductsDTO { id = 66, Name = "Magical Pig", Description ="Large Magical Pig", StockLevel = 21},
        };

        private readonly PriceHistoriesDTO[] _priceHistories =
        {
            new PriceHistoriesDTO { Id = 31, Price = 2.58, EffectiveFrom = DateTime.Now, ProductId = 5},
            new PriceHistoriesDTO { Id = 32, Price = 5.58, EffectiveFrom = DateTime.Now, ProductId = 3},
        };

        public Task<IEnumerable<ProductsDTO>> GetProducts()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories()
        {
            var priceHistories = _priceHistories.AsEnumerable();
            return Task.FromResult(priceHistories);
        }

        public Task<PriceHistoriesDTO> PushPrice(PriceHistoriesDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
