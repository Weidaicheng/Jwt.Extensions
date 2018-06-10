using JWT;
using JWT.Algorithms;
using JWT.Extensions.DependencyInjection;
using JWT.Serializers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using Xunit;

namespace Jwt.Extensions.Tests
{
    public class JwtServiceCollectionExtensionsTest
    {
        private readonly IWebHostBuilder _webHostBuilder;

        public JwtServiceCollectionExtensionsTest()
        {
            _webHostBuilder = new WebHostBuilder();
        }

        [Fact]
        public void IJwtAlgorithm_Should_Be_HMACSHA256Algorithm()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var algorithm = provider.GetRequiredService<IJwtAlgorithm>();
                algorithm.GetType().ShouldBe(typeof(HMACSHA256Algorithm));
            });
        }

        [Fact]
        public void IDateTimeProvider_Should_Be_UtcDateTimeProvider()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var dateTimeProvider = provider.GetRequiredService<IDateTimeProvider>();
                dateTimeProvider.GetType().ShouldBe(typeof(UtcDateTimeProvider));
            });
        }

        [Fact]
        public void IJsonSerializer_Should_Be_JsonNetSerializor()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var jsonSerializer = provider.GetRequiredService<IJsonSerializer>();
                jsonSerializer.GetType().ShouldBe(typeof(JsonNetSerializer));
            });
        }

        [Fact]
        public void IBase64UrlEncoder_Should_Be_JwtBase64UrlEncoder()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var urlEncoder = provider.GetRequiredService<IBase64UrlEncoder>();
                urlEncoder.GetType().ShouldBe(typeof(JwtBase64UrlEncoder));
            });
        }

        [Fact]
        public void IJwtValidator_Should_Be_JwtValidator()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var validator = provider.GetRequiredService<IJwtValidator>();
                validator.GetType().ShouldBe(typeof(JwtValidator));
            });
        }

        [Fact]
        public void IJwtEncoder_Should_Be_JwtEncoder()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var encoder = provider.GetRequiredService<IJwtEncoder>();
                encoder.GetType().ShouldBe(typeof(JwtEncoder));
            });
        }

        [Fact]
        public void IJwtDecoder_Should_Be_JwtDecoder()
        {
            _webHostBuilder.ConfigureServices(services =>
            {
                services.AddJwt();
                var provider = services.BuildServiceProvider();
                var decoder = provider.GetRequiredService<IJwtDecoder>();
                decoder.GetType().ShouldBe(typeof(JwtDecoder));
            });
        }
    }
}
