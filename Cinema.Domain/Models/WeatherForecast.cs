namespace Cinema.API.Models
{
    public record WeatherForecast(DateOnly Date, int TemperatureCelcius, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureCelcius / 0.5556);
    }
}