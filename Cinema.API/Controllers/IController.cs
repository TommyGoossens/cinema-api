namespace Cinema.API.Controllers
{
    public interface IController
    {
        /// <summary>
        /// Method to map all API endpoints per controller.
        /// </summary>
        /// <param name="app">WebApplication context to map the endpoints to</param>
        public void MapEndpoints(WebApplication app);
    }
}