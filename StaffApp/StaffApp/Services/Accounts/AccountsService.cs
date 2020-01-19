using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly HttpClient _client;

        public AccountsService(HttpClient client)
        {
            client.BaseAddress = new Uri("");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<PermissionsDTO>> GetPermissions()
        {
            var response = await _client.GetAsync("api/accounts/permissions");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<PermissionsDTO> permissions = await response.Content.ReadAsAsync<IEnumerable<PermissionsDTO>>();
            return permissions;
        }

        public async Task<IEnumerable<StaffAccountsDTO>> GetStaffAccounts()
        {
            var response = await _client.GetAsync("api/accounts/staff");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<StaffAccountsDTO> staffAccounts = await response.Content.ReadAsAsync<IEnumerable<StaffAccountsDTO>>();
            return staffAccounts;
        }

        public async Task<IEnumerable<UserAccountsDTO>> GetUserAccounts()
        {
            var response = await _client.GetAsync("api/accounts/permissions");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            IEnumerable<UserAccountsDTO> userAccounts = await response.Content.ReadAsAsync<IEnumerable<UserAccountsDTO>>();
            return userAccounts;
        }

        public async Task<UserAccountsDTO> PostUserAccount(UserAccountsDTO user)
        {
            var response = await _client.PostAsJsonAsync(
                "api/orders/", user);
            response.EnsureSuccessStatusCode();

            return user;
        }
    }
}
