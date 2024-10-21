using GloboClimaFrontend.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace GloboClimaFrontend.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public WeatherService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<WeatherResponse> GetWeatherByCityAsync(string cityName)
        {
            var url = $"/api/City/weather/{cityName}";

            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<WeatherResponse>(response);
        }
    }
}
