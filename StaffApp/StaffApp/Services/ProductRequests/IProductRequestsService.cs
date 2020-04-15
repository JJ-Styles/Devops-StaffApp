using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public interface IProductRequestsService
    {
        Task<IEnumerable<ProductRequestProductsDTO>> GetProductRequestProducts();

        Task<HttpResponseMessage> PushProductRequest(ProductRequestDTO productRequest);
    }
}
