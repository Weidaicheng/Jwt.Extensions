using JWT.Extensions.DependencyInjection.Options;
using JWT.Extensions.Exceptions;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// sample factory for token verifier
    /// </summary>
    public static class TokenVerifierFactory
    {
        /// <summary>
        /// get an instance of <see cref="ITokenVerifier"/>
        /// </summary>
        /// <param name="options"><see cref="JwtOptions"/></param>
        /// <returns>an instance of <see cref="ITokenVerifier"/></returns>
        public static ITokenVerifier GetTokenVerifier(JwtOptions options)
        {
            if (!string.IsNullOrEmpty(options.SecretStr))
                return new StringSecretTokenVerifier();
            else if (options.SecretBytes != null && options.SecretBytes.Length > 0)
                return new ByteArraySecretTokenVerifier();
            else
                throw new NoSecretSpecifiedException();
        }
    }
}
