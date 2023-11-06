using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace WeatherConsoleTask.Repository
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public WeatherService(IConfiguration config,HttpClient client)
        {
            _config = config;
            _client = client;
        }
        public async Task<string> GetWeatherData(string city,string countryCode)
        {
            string query = $"weather?q={city}";

            if (!string.IsNullOrWhiteSpace(countryCode))
            {
                query += $",{countryCode}";
            }

            string apiKey = _config["WeatherApi:ApiKey"];
            string baseUrl = _config["WeatherApi:BaseUrl"];
            string url = $"{baseUrl}/{query}&appid={apiKey}&units=metric";

            var weatherResponse = await _client.GetStringAsync(url);
            var data = JObject.Parse(weatherResponse);

            if (data["cod"].ToString() == "200")
            {
                var main = data["main"];
                var temperature = main["temp"];
                var description = data["weather"][0]["description"];

                string result = $"\nWeather in {city}{(string.IsNullOrWhiteSpace(countryCode) ? "" : $", {countryCode}")}:\n";
                result += $"Temperature: {temperature}°C\n";
                result += $"Description: {description}\n";

                return result;
            }
            else
            {
                return $"Error: {data["message"]}";
            }
        }
    }
}
