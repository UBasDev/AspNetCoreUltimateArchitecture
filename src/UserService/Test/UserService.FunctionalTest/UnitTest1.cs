using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using UserService.Api.Controllers;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserService.FunctionalTest
{
    public class UnitTest1: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        //private readonly IHostBuilder _hostBuilder;

        public UnitTest1(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test1()
        {
            /*
            var controller = new ProductsController();
            var actionResult = controller.Test1();

            var result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);

            var response = await _httpClient.GetAsync("");
            */

            string path2 = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + "appsettings.Testing.json";

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");

            var client = _factory.CreateClient();

            var response = await client.GetAsync("https://localhost:7188/api/Products/Test1");

            var stringResult = await response.Content.ReadAsStringAsync();

            //Assert.Equal("Development - value2-- Test1 çalýþtý!", stringResult);

            //response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        }

        /*
        [Fact]
        public async Task Test2()
        {
            var client = _factory.CreateClient();

            CreateProductDto requestBody = new()
            {
                Name="Product1",
                Price=100
            };

            string serializedRequestBody = JsonSerializer.Serialize(requestBody);

            var requestBodyToPost = new StringContent(serializedRequestBody, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7188/api/Products/Test2", requestBodyToPost);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        */

        public void Dispose()
        {
            //close down your test
        }
    }
}