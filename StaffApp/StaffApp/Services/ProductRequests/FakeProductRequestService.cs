using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public class FakeProductRequestService : IProductRequestsService
    {
        private readonly List<ProductRequestProductsDTO> _product = new List<ProductRequestProductsDTO>
            {
                new ProductRequestProductsDTO {Name = "Wrap It and Hope Cover", Price = 2.25},
                new ProductRequestProductsDTO {Name = "Non-conductive Screen Protector", Price = 5.00},
                new ProductRequestProductsDTO {Name = "Fish Scented Screen Protector", Price = 5.48},
                new ProductRequestProductsDTO {Name = "Rippled Screen Protector", Price = 15.48},
                new ProductRequestProductsDTO {Name = "Spray Paint Screen Protector", Price = 8.95},
                new ProductRequestProductsDTO {Name = "Real Pencil Stylus", Price = 10.53},
                new ProductRequestProductsDTO {Name = "Sticky Tape Sport Armband", Price = 15.40},
                new ProductRequestProductsDTO {Name = "Smartphone Car Holder", Price = 1.95},
                new ProductRequestProductsDTO {Name = "Water Bath Case", Price = 6.84},
                new ProductRequestProductsDTO {Name = "Harden Sponge Case", Price = 20.55},
                new ProductRequestProductsDTO {Name = "Cloth Cover", Price = 2.22},
                new ProductRequestProductsDTO {Name = "Chocolate Cover", Price = 3.45}
            };

        public Task<IEnumerable<ProductRequestProductsDTO>> GetProductRequestProducts()
        {
            var products = _product.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<HttpResponseMessage> PushProductRequest(ProductRequestDTO productRequest)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
