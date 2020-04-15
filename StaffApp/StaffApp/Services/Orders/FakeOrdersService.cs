using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Orders
{
    public class FakeOrdersService : IOrdersService
    {
        public Task<HttpResponseMessage> PushOrder(OrdersDTO order)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
