using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandomNumbers.Services.Implementations;
using RandomNumbers.Services.Interfaces;

namespace RandomNumbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IRandomNumberService, RandomNumberService>();
                    services.AddSingleton<ISorterService, SorterService>();
                    services.AddSingleton<IRequestSenderService, HttpRequestSenderService>();
                    services.AddHostedService<AppHostedService>();
                });
    }
}