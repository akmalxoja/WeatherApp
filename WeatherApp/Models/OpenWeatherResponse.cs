namespace WeatherApp.Models
{
    public class OpenWeatherResponse
    {
        public string Name { get; set; } // Shahar nomi
        public MainInfo Main { get; set; } // Ichki `main` obyekti
    }

    public class MainInfo
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public int Humidity { get; set; }
    }
}
