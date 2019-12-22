using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class Reviews
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public int ProductId { get; set; }
        public int UserAccountId { get; set; }
        public Product Products { get; set; }
        public UserAccount User { get; set; }
    }
}
