using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffApp.Web.Services
{
    public abstract class StaffAppServices
    {
        private HttpClient _client;

        public StaffAppServices(IHttpClientFactory clientFactory, string connection)
        {
            var client = clientFactory.CreateClient("RetryAndBreak");
            client.BaseAddress = new Uri(connection);
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public StaffAppServices()
        {
            _client = new HttpClient();
        }

        public void Setup(HttpClient client, string connection)
        {
            client.BaseAddress = new Uri(connection);
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public abstract Task<HttpResponseMessage> Post<T>(T data);

        public HttpClient GetClient()
        {
            return _client;
        }
    }
}
