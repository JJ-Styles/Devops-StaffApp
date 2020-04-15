using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public interface IInvoicesService
    {
        Task<HttpResponseMessage> PushInvoices(InvoicesDTO invoices);
    }
}
