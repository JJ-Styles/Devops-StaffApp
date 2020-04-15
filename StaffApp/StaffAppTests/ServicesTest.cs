using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using StaffApp.Web.Services;
using StaffApp.Web.Services.Accounts;
using StaffApp.Web.Services.Invoices;
using StaffApp.Web.Services.Orders;
using StaffApp.Web.Services.ProductRequests;
using StaffApp.Web.Services.Products;
using StaffApp.Web.Services.Reviews;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StaffAppTests
{
    [TestClass]
    public class ServicesTest
    {
        private readonly Dictionary<StaffAppServices, ServicesDTO> services = new Dictionary<StaffAppServices, ServicesDTO>()
        {
            { new AccountsService(), new UserAccountsDTO() },
            { new InvoicesService(), new InvoicesDTO() },
            {new OrdersService(), new OrdersDTO() },
            {new ProductRequestService(), new ProductRequestDTO() },
            {new ProductsService(), new PriceHistoriesDTO() },
            {new ReviewsService(), new ReviewsDTO() }
        };

        private readonly List<StaffAppServices> services1 = new List<StaffAppServices>()
        {
            new AccountsService(),
            new InvoicesService(),
            new OrdersService(),
            new ProductRequestService(),
            new ProductsService(),
            new ReviewsService()
        };

        private Mock<HttpMessageHandler> CreateHttpMoc()
        {
            var mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpResponseMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                            {
                                StatusCode = HttpStatusCode.OK
                            })
                .Verifiable();
            return mock;
        }

        private StaffAppServices CreateService(Mock<HttpMessageHandler> mock, StaffAppServices service)
        {
            var client = new HttpClient(mock.Object);
            service.Setup(client, "");
            return service;
        }

        [TestMethod]
        public async Task PostUserAccountTest_ShouldOkObjectAsync()
        {
            var expected = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };
            var mock = CreateHttpMoc();
            foreach(KeyValuePair<StaffAppServices, ServicesDTO> service in services)
            {
                var serviceTest = CreateService(mock, service.Key);
                var expectedUri = new Uri(serviceTest.GetClient().BaseAddress.ToString());
                var result = await serviceTest.Post(service.Value);

                Assert.IsNotNull(result);
                Assert.AreEqual(result.StatusCode, expected.StatusCode);
                mock.Protected()
                        .Verify("SendAsync",
                                Times.Once(),
                                ItExpr.Is<HttpRequestMessage>(
                                    req => req.Method == HttpMethod.Post
                                            && req.RequestUri == expectedUri),
                                ItExpr.IsAny<CancellationToken>()
                                );
            }
        }
    }
}
