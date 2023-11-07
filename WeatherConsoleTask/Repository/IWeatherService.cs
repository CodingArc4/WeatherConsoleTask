namespace WeatherConsoleTask.Repository
{
    public interface IWeatherService
    {
        Task<string> GetWeatherData(string city,string countryCode);
    }
}
