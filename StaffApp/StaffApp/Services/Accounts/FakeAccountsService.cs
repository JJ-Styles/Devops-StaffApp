using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class FakeAccountsService : IAccountsService
    {
        private readonly StaffAccountsDTO[] _staffAccounts =
        {
            new StaffAccountsDTO { Id = 47, Forename = "John", Surname = "Doe", PermissionId = 6},
            new StaffAccountsDTO { Id = 48, Forename = "Theresa", Surname = "Green", PermissionId = 6},
            new StaffAccountsDTO { Id = 49, Forename = "Macca", Surname = "Roni", PermissionId = 6},
            new StaffAccountsDTO { Id = 50, Forename = "Ben", Surname = "Dover", PermissionId = 6}
        };

        private readonly UserAccountsDTO[] _userAccounts =
        {
            new UserAccountsDTO { Id = 47, Forename = "Dean", Surname = "Winchester", Email = "deanwinchester@hunter.com", Active = true, PermissionsId = 9},
            new UserAccountsDTO { Id = 48, Forename = "Sam", Surname = "Winchester", Email = "samwinchester@hunter.com", Active = true, PermissionsId = 9},
            new UserAccountsDTO { Id = 49, Forename = "Castiel", Surname = "Winchester", Email = "castiel@heaven.com", Active = true, PermissionsId = 9},
            new UserAccountsDTO { Id = 50, Forename = "Crowley", Surname = "Hell", Email = "crowley@hell.com", Active = true, PermissionsId = 9},
            new UserAccountsDTO { Id = 51, Forename = "Jack", Surname = "Winchester", Email = "jackwinchester@hunter.com", Active = true, PermissionsId = 9},
        };

        private readonly PermissionsDTO[] _permissions =
        {
            new PermissionsDTO { CanAlterCustomers = true, CanAlterStaff = true, CanApproveDenyRequest = true, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = true, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
        };

        public Task<IEnumerable<PermissionsDTO>> GetPermissions()
        {
            var permissions = _permissions.AsEnumerable();
            return Task.FromResult(permissions);
        }

        public Task<IEnumerable<StaffAccountsDTO>> GetStaffAccounts()
        {
            var staffAccounts = _staffAccounts.AsEnumerable();
            return Task.FromResult(staffAccounts);
        }

        public Task<IEnumerable<UserAccountsDTO>> GetUserAccounts()
        {
            var userAccounts = _userAccounts.AsEnumerable();
            return Task.FromResult(userAccounts);
        }

        public Task<UserAccountsDTO> PostUserAccount(UserAccountsDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
