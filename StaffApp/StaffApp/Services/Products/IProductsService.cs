using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    interface IProductsService
    {
        Task<PriceHistoriesDTO> PushPrice(PriceHistoriesDTO product);

        Task<IEnumerable<ProductsDTO>> GetProducts();

        Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories();
    }
}
