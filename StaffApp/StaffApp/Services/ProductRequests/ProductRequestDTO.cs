using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.ProductRequests
{
    public class ProductRequestDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
    }
}
