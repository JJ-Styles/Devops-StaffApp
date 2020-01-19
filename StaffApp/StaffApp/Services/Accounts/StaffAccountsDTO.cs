using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class StaffAccountsDTO
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public int PermissionId { get; set; }
    }
}
