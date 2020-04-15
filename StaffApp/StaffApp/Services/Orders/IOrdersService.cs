using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Orders
{
    public interface IOrdersService
    {
        Task<HttpResponseMessage> PushOrder(OrdersDTO order);
    }
}
