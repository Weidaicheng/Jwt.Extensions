namespace JWT.Extensions.DependencyInjection.Options
{
    /// <summary>
    /// options
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// secret key of type <see cref="string"/>,
        /// if <see cref="SecretStr"/> and <see cref="SecretBytes"/> are specified at the same time, the <see cref="SecretStr"/> would be the priority choice
        /// </summary>
        public string SecretStr { get; set; }

        /// <summary>
        /// secret key of type <see cref="byte[]"/>,
        /// if <see cref="SecretStr"/> and <see cref="SecretBytes"/> are specified at the same time, the <see cref="SecretStr"/> would be the priority choice
        /// </summary>
        public byte[] SecretBytes { get; set; }

        /// <summary>
        /// token bearer location in <see cref="TokenBearer"/>, default location is at <see cref="TokenBearer.Header"/>
        /// </summary>
        public TokenBearer Bearer { get; set; } = TokenBearer.Header;

        /// <summary>
        /// token bearer key, default key is "Token"
        /// </summary>
        public string TokenBearerKey { get; set; } = "Token";

        /// <summary>
        /// redirect url for token verify failed
        /// </summary>
        public string RedirectUrl { get; set; }
    }

    /// <summary>
    /// token bearer location
    /// </summary>
    public enum TokenBearer
    {
        /// <summary>
        /// in request header
        /// </summary>
        Header,

        /// <summary>
        /// in request query string
        /// </summary>
        QueryString
    }
}
