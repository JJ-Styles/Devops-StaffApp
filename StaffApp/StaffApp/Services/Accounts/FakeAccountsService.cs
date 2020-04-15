using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public class FakeAccountsService : IAccountsService
    {
        public Task<HttpResponseMessage> PostUserAccount(UserAccountsDTO user)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
