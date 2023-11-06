using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherConsoleTask.Repository;

namespace WeatherConsoleTask
{
    class Program
    {
        private readonly IWeatherService _weatherService;

        public Program(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build())
                .AddScoped<IWeatherService, WeatherService>()
                .AddScoped<HttpClient>() 
                .AddScoped<Program>()
                .BuildServiceProvider();

            var program = serviceProvider.GetRequiredService<Program>();

            program.Run();
        }

        private void Run()
        {
            Console.Write("Enter City Name: ");
            string cityname = Console.ReadLine().Trim();

            Console.Write("Enter Country Code (optional, press Enter to skip): ");
            string countryCode = Console.ReadLine().Trim();

            string weatherData = _weatherService.GetWeatherData(cityname, countryCode).Result;

            Console.WriteLine(weatherData);
        }
    }
}