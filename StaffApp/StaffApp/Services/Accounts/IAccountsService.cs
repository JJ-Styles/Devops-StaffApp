using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services.Accounts
{
    public interface IAccountsService
    {
        Task<HttpResponseMessage> PostUserAccount(UserAccountsDTO user);
    }
}
