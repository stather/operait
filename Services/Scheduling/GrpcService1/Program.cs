using GrpcService1.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(5050, o => o.Protocols = HttpProtocols.Http2);
                });

                webBuilder.UseStartup<Startup>();
            });
    }
}