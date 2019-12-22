using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class ProductRequest
    {
        public int Id { get; set;}
        public string ProductName { get; set;}
        public double Price { get; set;}
        public int Quantity { get; set;}
        public bool Confirmed { get; set; }
    }
}
