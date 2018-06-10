namespace JWT.Extensions.DependencyInjection
{
    public interface IJwtBuilder
    {
        /// <summary>
        /// Add <see cref="Algorithms.IJwtAlgorithm"/>
        /// </summary>
        void AddAlgorithm();

        /// <summary>
        /// Add <see cref="IJsonSerializer"/>
        /// </summary>
        void AddSerializer();

        /// <summary>
        /// Add <see cref="IBase64UrlEncoder"/>
        /// </summary>
        void AddUrlEncoder();

        /// <summary>
        /// Add <see cref="IDateTimeProvider"/>
        /// </summary>
        void AddDateTimeProvider();

        /// <summary>
        /// Add <see cref="IJwtValidator"/>
        /// </summary>
        void AddValidator();

        /// <summary>
        /// Add <see cref="IJwtEncoder"/>
        /// </summary>
        void AddJwtEncoder();

        /// <summary>
        /// Add <see cref="JwtDecoder"/>
        /// </summary>
        void AddJwtDecoder();
    }
}
