using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Reviews
{
    public class ReviewsDTO : ServicesDTO
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public int ProductId { get; set; }
        public int UserAccountId { get; set; }
    }
}
