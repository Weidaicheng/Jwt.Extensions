using JWT;
using JWT.Extensions.Attributes;
using JWT.Extensions.DependencyInjection.Options;
using JWT.Extensions.Entity;
using JWT.Extensions.Mvc;
using JWT.Extensions.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Jwt.Extensions.Tests.TestWebApp.Controllers
{
    public class TestController : JwtControllerBase
    {
        private readonly IJwtEncoder _jwtEncoder;
        private readonly IJwtDecoder _jwtDecoder;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public TestController(IJwtEncoder jwtEncoder, IJwtDecoder jwtDecoder, IOptions<JwtOptions> jwtOptions)
        {
            _jwtEncoder = jwtEncoder;
            _jwtDecoder = jwtDecoder;
            _jwtOptions = jwtOptions;
        }

        public IActionResult GetToken(int exp = 0)
        {
            var token = _jwtEncoder.Encode(new Payload() { exp = UtilityHelper.GetTimeStamp() + exp }, _jwtOptions.Value.SecretStr);
            return Content(token);
        }

        public IActionResult Error()
        {
            return Content("Error");
        }

        [JwtCheck]
        public IActionResult NeedJwtCheck()
        {
            return Content("Success");
        }

        [JwtCheck(Ignore = true)]
        public IActionResult IgnoreJwtCheck()
        {
            return Content("Success");
        }
    }
}
