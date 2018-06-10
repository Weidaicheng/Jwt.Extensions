using JWT;
using JWT.Algorithms;
using JWT.Extensions.DependencyInjection;
using JWT.Serializers;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace Jwt.Extensions.Tests
{
    public class JwtServiceCollectionExtensionsTest
    {
        private readonly IServiceCollection _services;

        public JwtServiceCollectionExtensionsTest()
        {
            _services = new ServiceCollection();
            _services.AddOptions();
        }

        [Fact]
        public void IJwtAlgorithm_Should_Be_HMACSHA256Algorithm()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var algorithm = provider.GetRequiredService<IJwtAlgorithm>();
            algorithm.GetType().ShouldBe(typeof(HMACSHA256Algorithm));
        }

        [Fact]
        public void IDateTimeProvider_Should_Be_UtcDateTimeProvider()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var dateTimeProvider = provider.GetRequiredService<IDateTimeProvider>();
            dateTimeProvider.GetType().ShouldBe(typeof(UtcDateTimeProvider));
        }

        [Fact]
        public void IJsonSerializer_Should_Be_JsonNetSerializor()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var jsonSerializer = provider.GetRequiredService<IJsonSerializer>();
            jsonSerializer.GetType().ShouldBe(typeof(JsonNetSerializer));
        }

        [Fact]
        public void IBase64UrlEncoder_Should_Be_JwtBase64UrlEncoder()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var urlEncoder = provider.GetRequiredService<IBase64UrlEncoder>();
            urlEncoder.GetType().ShouldBe(typeof(JwtBase64UrlEncoder));
        }

        [Fact]
        public void IJwtValidator_Should_Be_JwtValidator()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var validator = provider.GetRequiredService<IJwtValidator>();
            validator.GetType().ShouldBe(typeof(JwtValidator));
        }

        [Fact]
        public void IJwtEncoder_Should_Be_JwtEncoder()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var encoder = provider.GetRequiredService<IJwtEncoder>();
            encoder.GetType().ShouldBe(typeof(JwtEncoder));
        }

        [Fact]
        public void IJwtDecoder_Should_Be_JwtDecoder()
        {
            _services.AddJwt();
            var provider = _services.BuildServiceProvider();
            var decoder = provider.GetRequiredService<IJwtDecoder>();
            decoder.GetType().ShouldBe(typeof(JwtDecoder));
        }
    }
}
