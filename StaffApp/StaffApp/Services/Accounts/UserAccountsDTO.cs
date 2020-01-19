using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class UserAccountsDTO
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Email { get; set; }
        public int PermissionsId { get; set; }
        public bool Active { get; set; }
    }
}
