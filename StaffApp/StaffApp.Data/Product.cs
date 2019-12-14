using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class Product
    {
        public int id { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public int StockLevel { get; set; }
        public IEnumerable<PriceHistory> Price { get; set;}
    }
}
