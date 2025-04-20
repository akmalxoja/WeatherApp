namespace WeatherApp.Models
{
    public class Weather
    {
        public int Id { get; set; }                // Primary key
        public string City { get; set; }           // Shahar nomi
        public float Temperature { get; set; }     // Hozirgi harorat
        public float FeelsLike { get; set; }       // His qilinadigan harorat
        public int Humidity { get; set; }          // Namlik foizi
        public DateTime RetrievedAt { get; set; } = DateTime.UtcNow; // API'dan olingan vaqt
    }

}
