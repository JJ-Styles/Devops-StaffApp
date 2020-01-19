using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public class FakeProductRequestService : IProductRequestsService
    {
        private readonly ProductRequestDTO[] _productRequests =
        {

        };

        public Task<IEnumerable<ProductRequestDTO>> GetProductRequest()
        {
            var productRequests = _productRequests.AsEnumerable();
            return Task.FromResult(productRequests);
        }

        public Task<ProductRequestDTO> PushProductRequest(ProductRequestDTO productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
