using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffApp.Data;

namespace StaffApp.Web.Services.Orders
{
    public class OrdersDTO : ServicesDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public int InvoiceId { get; set; }
        public bool Dispatched { get; set; }
        public DateTime? DispatchDate { get; set; }
    }
}
