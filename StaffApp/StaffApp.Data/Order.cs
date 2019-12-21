using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class Order
    {
        public int Id { get; set;}
        public int ProductId { get; set;}
        public int Quantity { get; set;}
        public double Cost { get; set; }
        public int InvoiceId { get; set; }
        public DateTime DispatchDate { get; set; }
        public Product Products { get; set; }
        public Invoice Invoices { get; set; }
    }
}
