using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RandomNumbers.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RandomNumbers
{
    public class AppHostedService : IHostedService
    {
        private const int MinNumber = -100;
        private const int MaxCount = 100;
        private const int MinNumberCount = 20;
        private const int MaxNumberCount = 100;


        private readonly IConfiguration _configuration;
        private readonly IRandomNumberService _randomNumberService;
        private readonly ISorterService _sorterService;
        private readonly IHost _host;
        private readonly IRequestSenderService _requestSenderService;

        public AppHostedService(
            IConfiguration configuration,
            IRandomNumberService randomNumberService,
            ISorterService sorterService, IHost host,
            IRequestSenderService requestSenderService
        )
        {
            _configuration = configuration;
            _randomNumberService = randomNumberService;
            _sorterService = sorterService;
            _host = host;
            _requestSenderService = requestSenderService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var countNumbers = _randomNumberService.Generate(MinNumberCount, MaxNumberCount);

            var numbers = new int[countNumbers];

            for (var i = 0; i < countNumbers; i++)
            {
                numbers[i] = _randomNumberService.Generate(MinNumber, MaxCount);
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");

            _sorterService.Sort(numbers);

            Console.WriteLine($"[{string.Join(", ", numbers)}]");

            await _requestSenderService.SendAsync(_configuration["RemoteServer"], numbers);

            await _host.StopAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}