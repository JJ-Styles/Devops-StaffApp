using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Orders
{
    public interface IOrdersService
    {
        Task<OrdersDTO> PushOrder(OrdersDTO order);

        Task<IEnumerable<OrdersDTO>> GetOrders(); 
    }
}
