using JWT.Extensions.DependencyInjection.Options;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// token verifier
    /// </summary>
    public interface ITokenVerifier
    {
        /// <summary>
        /// verify token
        /// </summary>
        /// <param name="jwtDecoder">jwt decoder</param>
        /// <param name="token">token string</param>
        /// <param name="options">jwt options</param>
        /// <returns>if the verify of token is success</returns>
        bool VerifyToken(IJwtDecoder jwtDecoder, string token, JwtOptions options);
    }
}
