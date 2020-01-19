using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public interface IAccountsService
    {
        Task<IEnumerable<UserAccountsDTO>> GetUserAccounts();

        Task<IEnumerable<StaffAccountsDTO>> GetStaffAccounts();

        Task<IEnumerable<PermissionsDTO>> GetPermissions();

        Task<UserAccountsDTO> PostUserAccount(UserAccountsDTO user);
    }
}
