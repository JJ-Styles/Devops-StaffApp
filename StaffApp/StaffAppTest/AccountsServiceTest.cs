using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using StaffApp.Web.Services.Accounts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StaffAppTest
{
    [TestClass]
    public class AccountsServiceTest
    {
        private Mock<HttpMessageHandler> CreateHttpMock(HttpResponseMessage expected)
        {
            var mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(expected)
                .Verifiable();
            return mock;
        }

        private AccountsService CreateService(Mock<HttpMessageHandler> mock)
        {
            //var client = new IHttpClientFactory(mock.Object);
            return new AccountsService(client);
        }

        [TestMethod]
        public void PostUserAccount_ShouldOkObject()
        {
            
        }
    }
}
