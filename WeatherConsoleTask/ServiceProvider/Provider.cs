using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
