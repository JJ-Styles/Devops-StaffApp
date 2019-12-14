using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class StaffPermissions
    {
        public int StaffId { get; set; }
        public int PermissionId { get; set; }

        public IEnumerable<StaffAccount> Staff { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
