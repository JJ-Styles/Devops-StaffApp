using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public class FakeInvoicesServic : IInvoicesService
    {
        private readonly InvoicesDTO[] _invoices =
        {
            new InvoicesDTO { Id = 57, Invoiced = false, StaffAccountId = 7, UserAccountId = 6},
            new InvoicesDTO { Id = 58, Invoiced = false, StaffAccountId = 1, UserAccountId = 10},
            new InvoicesDTO { Id = 59, Invoiced = false, StaffAccountId = 4, UserAccountId = 1},
        };

        public Task<IEnumerable<InvoicesDTO>> GetInvoices()
        {
            var order = _invoices.AsEnumerable();
            return Task.FromResult(order);
        }

        public Task<InvoicesDTO> PushInvoices(InvoicesDTO invoices)
        {
            throw new NotImplementedException();
        }
    }
}
