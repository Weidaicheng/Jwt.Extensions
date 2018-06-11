using Microsoft.AspNetCore.Http;
using JWT.Extensions.DependencyInjection.Options;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// token gainer
    /// </summary>
    public interface ITokenGainer
    {
        /// <summary>
        /// gain token
        /// </summary>
        /// <param name="request"><see cref="HttpRequest"/></param>
        /// <param name="key"><see cref="JwtOptions.TokenBearerKey"/></param>
        /// <returns></returns>
        string GainToken(HttpRequest request, string key);
    }
}
