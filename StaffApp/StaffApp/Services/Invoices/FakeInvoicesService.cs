using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public class FakeInvoicesService : IInvoicesService
    {
        public Task<HttpResponseMessage> PushInvoices(InvoicesDTO invoices)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
