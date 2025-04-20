using WeatherApp.Models;

namespace WeatherApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        public Task AddAsync(Weather weather)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Weather>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Weather?> GetByCityAsync(string city)
        {
            throw new NotImplementedException();
        }
    }
}
