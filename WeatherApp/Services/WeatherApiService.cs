using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "sadas";

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherFromApiAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

            var data  = JsonSerializer.Deserialize<OpenWeatherResponse>(json);

            return new Weather
            {
                City = data.Name,
                Temperature = data.Main.Temp,
                FeelsLike = data.Main.Feels_like,
                Humidity = data.Main.Humidity,
               
            };
            //
        }
    }
}
