using Microsoft.Extensions.Logging;
using RandomNumbers.Services.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RandomNumbers.Services.Implementations
{
    public class HttpRequestSenderService : IRequestSenderService
    {
        private readonly HttpClient _httpClient = new();
        private readonly ILogger<HttpRequestSenderService> _logger;

        public HttpRequestSenderService(ILogger<HttpRequestSenderService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SendAsync(string path, object model)
        {
            try
            {
                var stringContent = 
                    new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(path, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return false;
        }
    }
}