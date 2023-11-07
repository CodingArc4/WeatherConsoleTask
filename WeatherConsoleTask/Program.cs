using Microsoft.Extensions.DependencyInjection;
using WeatherConsoleTask.Repository;
using WeatherConsoleTask.ServiceProvider;

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
            var collection = new ServiceCollection();
            var service = new Provider();
            service.Services(collection);

            var provider = collection.BuildServiceProvider();

            var program = provider.GetRequiredService<Program>();

            program.Weather();
        }

        private void Weather()
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