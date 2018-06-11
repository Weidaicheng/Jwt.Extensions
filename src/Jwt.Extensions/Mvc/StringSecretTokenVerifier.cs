using JWT.Extensions.DependencyInjection.Options;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// token verifier with <see cref="string"/> secret
    /// </summary>
    public class StringSecretTokenVerifier : ITokenVerifier
    {
        public bool VerifyToken(IJwtDecoder jwtDecoder, string token, JwtOptions options)
        {
            return jwtDecoder.TryDecode(token, options.SecretStr, out string result);
        }
    }
}
