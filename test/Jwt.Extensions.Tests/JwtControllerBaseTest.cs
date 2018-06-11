using Jwt.Extensions.Tests.TestWebApp;
using JWT;
using JWT.Extensions.Attributes;
using JWT.Extensions.DependencyInjection;
using JWT.Extensions.DependencyInjection.Options;
using JWT.Extensions.Entity;
using JWT.Extensions.Mvc;
using JWT.Extensions.Utility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jwt.Extensions.Tests
{
    public class JwtControllerBaseTest
    {
        private readonly HttpClient _client;

        public JwtControllerBaseTest()
        {
            _client = new HttpClient();

            Program.StartWebApp();
        }

        [Fact]
        public async Task Should_Get_Token()
        {
            var response = await _client.GetAsync("http://localhost:5000/Test/GetToken");
            var responseStr = await response.Content.ReadAsStringAsync();
            responseStr.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact]
        public async Task Should_Get_Success()
        {
            //get token
            var response = await _client.GetAsync("http://localhost:5000/Test/GetToken?exp=10");
            var token = await response.Content.ReadAsStringAsync();

            //access NeedJwtCheck
            response = await _client.GetAsync($"http://localhost:5000/Test/NeedJwtCheck?Token={token}");
            var responseStr = await response.Content.ReadAsStringAsync();

            //Assert
            responseStr.ToLower().ShouldBe("success");
        }

        [Fact]
        public async Task JwtCheck_Should_Get_Error()
        {
            //get token
            var response = await _client.GetAsync("http://localhost:5000/Test/GetToken");
            var token = await response.Content.ReadAsStringAsync();

            //access NeedJwtCheck
            response = await _client.GetAsync($"http://localhost:5000/Test/NeedJwtCheck?Token={token}");
            var responseStr = await response.Content.ReadAsStringAsync();

            //Assert
            responseStr.ToLower().ShouldBe("error");
        }

        [Fact]
        public async Task Ignore_JwtCheck_Should_Get_Success()
        {
            //get token
            var response = await _client.GetAsync("http://localhost:5000/Test/GetToken");
            var token = await response.Content.ReadAsStringAsync();

            //access NeedJwtCheck
            response = await _client.GetAsync($"http://localhost:5000/Test/IgnoreJwtCheck?Token={token}");
            var responseStr = await response.Content.ReadAsStringAsync();

            //Assert
            responseStr.ToLower().ShouldBe("success");
        }
    }
    
}
