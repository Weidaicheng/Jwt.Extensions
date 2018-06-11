using JWT.Extensions.DependencyInjection.Options;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// simple factory for token gainer
    /// </summary>
    public static class TokenGainerFactory
    {
        /// <summary>
        /// get an instance of <see cref="ITokenGainer"/>
        /// </summary>
        /// <param name="bearer">the location of token bearer, see <see cref="TokenBearer"/></param>
        /// <returns>an instance of <see cref="ITokenGainer"/></returns>
        public static ITokenGainer GetTokenGainer(TokenBearer bearer)
        {
            if (bearer == TokenBearer.Header)
                return new HeaderTokenGainer();
            else if (bearer == TokenBearer.QueryString)
                return new QueryStringTokenGainer();
            else
                return null;
        }
    }
}
