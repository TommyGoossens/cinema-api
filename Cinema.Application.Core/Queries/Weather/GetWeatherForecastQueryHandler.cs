using Cinema.API.Models;
using MediatR;

namespace Cinema.Application.Core.Queries.Weather
{
    public record GetWeatherForecastQuery() : IRequest<IEnumerable<WeatherForecast>>;

    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly string[] summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 35),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
            return await Task.FromResult(forecast);
        }
    }
}

