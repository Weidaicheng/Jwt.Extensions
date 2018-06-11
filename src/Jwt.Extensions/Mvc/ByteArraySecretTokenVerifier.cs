using JWT.Extensions.DependencyInjection.Options;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// token verifier with <see cref="byte[]"/> secret
    /// </summary>
    public class ByteArraySecretTokenVerifier : ITokenVerifier
    {
        public bool VerifyToken(IJwtDecoder jwtDecoder, string token, JwtOptions options)
        {
            return jwtDecoder.TryDecode(token, options.SecretBytes, out string result);
        }
    }
}
