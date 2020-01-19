using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public interface IInvoicesService
    {
        Task<InvoicesDTO> PushInvoices(InvoicesDTO invoices);

        Task<IEnumerable<InvoicesDTO>> GetInvoices();
    }
}
