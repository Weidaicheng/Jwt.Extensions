using JWT;
using JWT.Extensions;
using JWT.Extensions.DependencyInjection;
using JWT.Extensions.Entity;
using JWT.Extensions.Utility;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Jwt.Extensions.Tests
{
    public class IJwtDecoderExtensionsTest
    {
        private readonly IJwtEncoder _jwtEncoder;
        private readonly IJwtDecoder _jwtDecoder;

        private const string secret = "secret";

        public IJwtDecoderExtensionsTest()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddJwt();

            var provider = services.BuildServiceProvider();
            _jwtEncoder = provider.GetRequiredService<IJwtEncoder>();
            _jwtDecoder = provider.GetRequiredService<IJwtDecoder>();
        }

        [Fact]
        public void TryDecode_String_Return_Result_Should_Be_True()
        {
            var token = _jwtEncoder.Encode(new Payload() { exp = UtilityHelper.GetTimeStamp() + 60 }, secret);
            _jwtDecoder.TryDecode(token, secret, out string result).ShouldBe(true);
        }

        [Fact]
        public async Task TryDecode_String_Return_Result_Should_Be_False()
        {
            var token = _jwtEncoder.Encode(new Payload() { exp = UtilityHelper.GetTimeStamp() }, secret);
            await Task.Delay(1000);
            _jwtDecoder.TryDecode(token, secret, out string result).ShouldBe(false);
        }

        [Fact]
        public void TryDecode_PayloadObject_Return_Result_Should_Be_True()
        {
            var token = _jwtEncoder.Encode(new Payload() { exp = UtilityHelper.GetTimeStamp() + 60 }, secret);
            _jwtDecoder.TryDecodeToObject<Payload>(token, secret, out Payload result).ShouldBe(true);
        }

        [Fact]
        public async Task TryDecode_PayloadObject_Return_Result_Should_Be_False()
        {
            var token = _jwtEncoder.Encode(new Payload() { exp = UtilityHelper.GetTimeStamp() }, secret);
            await Task.Delay(1000);
            _jwtDecoder.TryDecodeToObject<Payload>(token, secret, out Payload result).ShouldBe(false);
        }
    }
}
