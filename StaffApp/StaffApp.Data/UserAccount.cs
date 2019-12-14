using System;
using System.Collections.Generic;
using System.Text;

namespace StaffApp.Data
{
    public class UserAccount
    {
        public int UserId { get; set;}
        public string Surname { get; set;}
        public string Forename { get; set; }
        public string Email { get; set;}
        public int PermissionsId { get; set;}
        public Permissions Permission { get; set;}
    }
}
