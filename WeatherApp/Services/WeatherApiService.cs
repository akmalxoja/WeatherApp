using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "1693ab4e6cd64db841cb11b20be8f662";

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherFromApiAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

           // var data  = JsonSerializer.Deserialize<OpenWeatherResponse>(json);


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<OpenWeatherResponse>(json, options);


            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API so‘rovida xatolik: {response.StatusCode}");
            }


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
