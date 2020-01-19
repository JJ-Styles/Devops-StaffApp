using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly HttpClient _client;

        public OrdersService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<OrdersDTO>> GetOrders()
        {
            var response = await _client.GetAsync("api/orders/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<OrdersDTO> orders = await response.Content.ReadAsAsync<IEnumerable<OrdersDTO>>();
            return orders;
        }

        public async Task<OrdersDTO> PushOrder(OrdersDTO order)
        {
            var response = await _client.PostAsJsonAsync(
                "api/orders/", order);
            response.EnsureSuccessStatusCode();

            return order;
        }
    }
}
