using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public interface IProductsService
    {
        Task<HttpResponseMessage> PushPrice(PriceHistoriesDTO product);

        Task<IEnumerable<PriceHistoriesDTO>> GetPriceHistories();
    }
}
