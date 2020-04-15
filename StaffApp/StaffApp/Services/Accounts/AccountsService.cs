using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class AccountsService : StaffAppServices, IAccountsService
    {
        public AccountsService(IHttpClientFactory clientFactory) : base(clientFactory, "")
        {
        }

        public AccountsService() : base()
        {
        }

        public async Task<HttpResponseMessage> PostUserAccount(UserAccountsDTO user)
        {
            return await GetClient().PostAsJsonAsync("api/accounts/", user);
        }

        public override async Task<HttpResponseMessage> Post<T>(T data)
        {
            var user = new UserAccountsDTO();
            if(!UserAccountsDTO.ReferenceEquals(data.GetType(), user))
            {
                return null;
            }
            user = (UserAccountsDTO)nameof(data).Clone();
            return await PostUserAccount(user);
        }
    }
}
