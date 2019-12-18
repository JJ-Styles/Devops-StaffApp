using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class Invoice
    {
        public int Id { get; set; }
        public bool Invoiced { get; set;}
        public int UserAccountId { get; set; }
        public int StaffAccountId { get; set;}
        public UserAccount User { get; set; }
        public StaffAccount Staff { get; set;}
    }
}
