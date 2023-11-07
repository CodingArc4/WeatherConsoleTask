using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherConsoleTask.Repository;

namespace WeatherConsoleTask.ServiceProvider
{
    public class Provider
    {
        public void Services(IServiceCollection collection)
        {
            collection.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build());
            collection.AddScoped<IWeatherService, WeatherService>();
            collection.AddScoped<HttpClient>();
            collection.AddScoped<Program>();
        }
    }
}
