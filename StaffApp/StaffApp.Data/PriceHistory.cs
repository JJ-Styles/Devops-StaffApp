using System;

namespace StaffApp.Data
{
    public class PriceHistory
    {
        public int productId { get; set;}
        public DateTime EffectiveFrom { get; set;}
        public double price { get; set;}
    }
}