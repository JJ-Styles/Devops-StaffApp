using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Products
{
    public class PriceHistoriesDTO : ServicesDTO
    {
        public int Id { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
    }
}
