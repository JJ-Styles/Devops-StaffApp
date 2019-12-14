using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    class Order
    {
        public int Id { get; set;}
        public int ProductId { get; set;}
        public int Quantity { get; set;}
        public double Cost { get; set; }
    }
}
