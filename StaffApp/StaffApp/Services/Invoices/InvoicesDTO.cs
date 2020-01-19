using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Invoices
{
    public class InvoicesDTO
    {
        public int Id { get; set; }
        public bool Invoiced { get; set; }
        public int UserAccountId { get; set; }
        public int StaffAccountId { get; set; }
    }
}
