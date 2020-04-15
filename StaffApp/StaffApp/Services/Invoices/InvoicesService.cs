using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public class InvoicesService : StaffAppServices, IInvoicesService
    {

        public InvoicesService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public InvoicesService() : base()
        {
        }

        public async Task<HttpResponseMessage> PushInvoices(InvoicesDTO invoices)
        {
            return await GetClient().PostAsJsonAsync("api/invoices/", invoices);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var invoices = new InvoicesDTO();
            if (!InvoicesDTO.ReferenceEquals(data.GetType(), invoices))
            {
                return null;
            }
            invoices = (InvoicesDTO)nameof(data).Clone();
            return await PushInvoices(invoices);
        }
    }
}
