using JWT.Extensions.DependencyInjection.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JWT.Extensions.DependencyInjection
{
    public static class JwtServiceCollectionExtensions
    {
        /// <summary>
        /// Add Jwt
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns></returns>
        public static IJwtBuilder AddJwt(this IServiceCollection services)
        {
            IJwtBuilder builder = new JwtBuilder(services);

            //add services...
            builder.AddAlgorithm();
            builder.AddSerializer();
            builder.AddUrlEncoder();
            builder.AddDateTimeProvider();
            builder.AddValidator();
            builder.AddJwtEncoder();
            builder.AddJwtDecoder();

            return builder;
        }

        /// <summary>
        /// Add Jwt
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="setupAction">The setup action</param>
        /// <returns></returns>
        public static IJwtBuilder AddJwt(this IServiceCollection services, Action<JwtOptions> setupAction)
        {
            services.Configure(setupAction);
            return AddJwt(services);
        }

        /// <summary>
        /// Add Jwt
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns></returns>
        public static IJwtBuilder AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration);
            return AddJwt(services);
        }
    }
}
