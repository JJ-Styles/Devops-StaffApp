using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class UserAccount
    {
        public int UserId { get; set;}
        public string Name { get; set;}
        public string Email { get; set;}
        public int PermissionsId { get; set;}
        public Permission Permissions { get; set;}
    }
}
