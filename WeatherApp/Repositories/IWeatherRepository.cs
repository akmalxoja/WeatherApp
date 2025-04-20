using WeatherApp.Models;

namespace WeatherApp.Repositories
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<Weather>> GetAllAsync();
        Task<Weather?> GetByCityAsync(string city);
        Task AddAsync(Weather weather);
    }
}
