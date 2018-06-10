using JWT.Algorithms;
using JWT.Extensions.DependencyInjection.Options;
using JWT.Serializers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace JWT.Extensions.DependencyInjection
{
    public class JwtBuilder : IJwtBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IServiceProvider _provider;
        private readonly JwtOptions _options;

        public JwtBuilder(IServiceCollection services)
        {
            _services = services;
            _provider = _services.BuildServiceProvider();
            _options = _provider.GetRequiredService<IOptions<JwtOptions>>().Value;
        }

        public void AddAlgorithm()
        {
            _services.AddSingleton<IJwtAlgorithm, HMACSHA256Algorithm>();
        }

        public void AddDateTimeProvider()
        {
            _services.AddSingleton<IDateTimeProvider, UtcDateTimeProvider>();
        }

        public void AddSerializer()
        {
            _services.AddSingleton<IJsonSerializer, JsonNetSerializer>();
        }

        public void AddUrlEncoder()
        {
            _services.AddSingleton<IBase64UrlEncoder, JwtBase64UrlEncoder>();
        }

        public void AddValidator()
        {
            _services.AddSingleton<IJwtValidator>(provider =>
            {
                var jsonSerializer = provider.GetRequiredService<IJsonSerializer>();
                var dateTimeProvider = provider.GetRequiredService<IDateTimeProvider>();
                return new JwtValidator(jsonSerializer, dateTimeProvider);
            });
        }

        public void AddJwtEncoder()
        {
            _services.AddSingleton<IJwtEncoder>(provider =>
            {
                var algorithm = provider.GetRequiredService<IJwtAlgorithm>();
                var jsonSerializer = provider.GetRequiredService<IJsonSerializer>();
                var urlEncoder = provider.GetRequiredService<IBase64UrlEncoder>();
                return new JwtEncoder(algorithm, jsonSerializer, urlEncoder);
            });
        }

        public void AddJwtDecoder()
        {
            _services.AddSingleton<IJwtDecoder>(provider =>
            {
                var jsonSerializer = provider.GetRequiredService<IJsonSerializer>();
                var jwtValidator = provider.GetRequiredService<IJwtValidator>();
                var urlEncoder = provider.GetRequiredService<IBase64UrlEncoder>();
                return new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder);
            });
        }
    }
}
