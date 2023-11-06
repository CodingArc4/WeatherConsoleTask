using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WeatherConsoleTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Configuration to run appsetting.json
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            var client = new HttpClient();

            //Enter City Name 
            Console.Write("Enter City Name To View The Weather: ");
            var cityname = Console.ReadLine().ToLower();

            //Enter Location
            Console.Write("Enter Country Code (optional, press Enter to skip): ");
            string countryCode = Console.ReadLine().Trim();

            string query = $"weather?q={cityname}";
            if (!string.IsNullOrWhiteSpace(countryCode))
            {
                query += $",{countryCode}";
            }

            //Url of the WeatherAPi
            var url = $"{config["WeatherApi:BaseUrl"]}/{query}&appid={config["WeatherAPi:ApiKey"]}&units=metric";

            //Json Parse
            var weatherResponse = client.GetStringAsync(url).Result;
            var data = JObject.Parse(weatherResponse);

            if (data["cod"].ToString() == "200")
            {
                var main = data["main"];
                var temperature = main["temp"];
                var description = data["weather"][0]["description"];

                Console.WriteLine($"\nWeather in {cityname}{(string.IsNullOrWhiteSpace(countryCode) ? "" : $", {countryCode}")}:");
                Console.WriteLine($"Temperature: {temperature}°C");
                Console.WriteLine($"Description: {description}");
            }
        }
    }
}