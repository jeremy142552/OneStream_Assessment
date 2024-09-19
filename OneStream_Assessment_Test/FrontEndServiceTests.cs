using System.Net;
using Microsoft.AspNetCore.Http;
using Moq;
using Moq.Protected;
using OneStream_Assessment_Services.FrontEndService;

namespace OneStream_Assessment_Tests
{
    public class FrontEndServiceTests
    {
        private readonly Mock<IHttpClientFactory> _mockHttpClientFactory;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly FrontEndService _frontEndService;

        public FrontEndServiceTests()
        {
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            // Setup HttpContextAccessor mock
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "https";
            httpContext.Request.Host = new HostString("localhost:5001");
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(httpContext);

            _frontEndService = new FrontEndService(_mockHttpClientFactory.Object, _mockHttpContextAccessor.Object);
        }

        [Fact]
        public async Task CallApi1_ShouldReturnExpectedResult()
        {
            // Arrange
            var expectedResponse = "API1 Response";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var result = await _frontEndService.CallApi1();

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task CallApi2_ShouldReturnExpectedResult()
        {
            // Arrange
            var expectedResponse = "API2 Response";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var result = await _frontEndService.CallApi2();

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task PostToApi1_ShouldReturnExpectedResult()
        {
            // Arrange
            var expectedResponse = "API1 Post Response";
            var postData = new { Data = "Test Data" };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var result = await _frontEndService.PostToApi1(postData);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task PostToApi2_ShouldReturnExpectedResult()
        {
            // Arrange
            var expectedResponse = "API2 Post Response";
            var postData = new { Data = "Test Data" };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                });

            var client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };

            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var result = await _frontEndService.PostToApi1(postData);

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}