﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class PermissionsDTO
    {
        public int Id { get; set; }
        public bool CanOrder { get; set; }
        public bool CanOrderNewStock { get; set; }
        public bool CanAlterCustomers { get; set; }
        public bool CanSetResellPrice { get; set; }
        public bool CanViewOrders { get; set; }
        public bool CanViewCustomers { get; set; }
        public bool CanHideReviews { get; set; }
        public bool CanDeleteCustomers { get; set; }
        public bool CanAlterStaff { get; set; }
        public bool CanApproveDenyRequest { get; set; }
    }
}
