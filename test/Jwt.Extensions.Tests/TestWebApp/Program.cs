using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Jwt.Extensions.Tests.TestWebApp
{
    public class Program
    {
        public async static Task StartWebApp()
        {
            await Task.Run(() =>
            {
                WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build()
                .Run();
            });
        }
    }
}
