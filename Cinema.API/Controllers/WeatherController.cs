using Cinema.Application.Core.Queries.Weather;
using MediatR;

namespace Cinema.API.Controllers
{
    public class WeatherController : IController
    {
        public void MapEndpoints(WebApplication app)
        {
            app.MapGet("/weatherforecast", (IMediator mediatr) => mediatr.Send(new GetWeatherForecastQuery()))
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        }
    }
}