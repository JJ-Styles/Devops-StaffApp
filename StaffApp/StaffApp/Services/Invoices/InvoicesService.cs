using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public class InvoicesService : IInvoicesService
    {
        private readonly HttpClient _client;

        public InvoicesService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<InvoicesDTO>> GetInvoices()
        {
            var response = await _client.GetAsync("api/invoices/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<InvoicesDTO> invoices = await response.Content.ReadAsAsync<IEnumerable<InvoicesDTO>>();
            return invoices;
        }

        public async Task<InvoicesDTO> PushInvoices(InvoicesDTO invoices)
        {
            var response = await _client.PostAsJsonAsync(
                "api/invoices/", invoices);
            response.EnsureSuccessStatusCode();

            return invoices;
        }
    }
}
