using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly AppDbContext _context;
        public WeatherRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            return await _context.weathers.ToListAsync();
        }

        public async Task AddAsync(Weather weather)
        {
            _context.weathers.Add(weather);
            await _context.SaveChangesAsync();
        }


        public async Task<Weather?> GetByCityAsync(string city)
        {
           return await _context.weathers.FirstOrDefaultAsync(x => x.City.ToLower ()== city.ToLower());
        }
    }
}
