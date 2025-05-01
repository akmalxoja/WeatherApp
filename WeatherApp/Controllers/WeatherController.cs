using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Repositories;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _repo;
        private readonly WeatherApiService _api;


        public WeatherController(IWeatherRepository repo, WeatherApiService api)
        {
            _repo = repo;
            _api = api;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var cached = await _repo.GetByCityAsync(city);

            if(cached != null && cached.RetrievedAt > DateTime.UtcNow.AddMinutes(-30))
            {
                return Ok(cached);
            }

            var fresh  = await _api.GetWeatherFromApiAsync(city);
            await _repo.AddAsync(fresh);

            return Ok(fresh);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWeather()
        {
            var weathers = await _repo.GetAllAsync();
            return Ok(weathers);
        }

    }
}
