using Cinema.API.Controllers;

namespace Cinema.API.Extensions
{
    public static class AppControllerMapper
    {
        public static void MapControllerRoutes(this WebApplication app)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var classes = assemblies.Distinct().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IController).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var c in classes)
            {
                var instance = Activator.CreateInstance(c) as IController;
                instance?.MapEndpoints(app);
            }
        }
    }
}