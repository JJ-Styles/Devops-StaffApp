using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Orders
{
    public class OrdersService : StaffAppServices, IOrdersService
    {
        public OrdersService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public OrdersService() : base()
        {
        }

        public async Task<HttpResponseMessage> PushOrder(OrdersDTO order)
        {
            return await GetClient().PostAsJsonAsync("api/orders/", order);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var Orders = new OrdersDTO();
            if (!OrdersDTO.ReferenceEquals(data.GetType(), Orders))
            {
                return null;
            }
            Orders = (OrdersDTO)nameof(data).Clone();
            return await PushOrder(Orders);
        }
    }
}
