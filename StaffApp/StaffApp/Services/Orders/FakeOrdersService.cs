using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services
{
    public class FakeOrdersService : IOrdersService
    {
        private readonly OrdersDTO[] _orders =
        {
            new OrdersDTO { Id = 54, Cost = 53.14, DispatchDate = null, Dispatched = false, Quantity = 50, InvoiceId = 14, ProductId = 5},
            new OrdersDTO { Id = 55, Cost = 97.15, DispatchDate = null, Dispatched = false, Quantity = 90, InvoiceId = 14, ProductId = 5},
            new OrdersDTO { Id = 56, Cost = 15.10, DispatchDate = null, Dispatched = false, Quantity = 10, InvoiceId = 14, ProductId = 5},
        };

        public Task<IEnumerable<OrdersDTO>> GetOrders()
        {
            var order = _orders.AsEnumerable();
            return Task.FromResult(order);
        }

        public Task<OrdersDTO> PushOrder(OrdersDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
