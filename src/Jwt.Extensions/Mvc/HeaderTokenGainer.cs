using Microsoft.AspNetCore.Http;

namespace JWT.Extensions.Mvc
{
    /// <summary>
    /// gain token from request header
    /// </summary>
    public class HeaderTokenGainer : ITokenGainer
    {
        public string GainToken(HttpRequest request, string key)
        {
            return request.Headers[key];
        }
    }
}
