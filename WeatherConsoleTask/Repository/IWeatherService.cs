using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsoleTask.Repository
{
    public interface IWeatherService
    {
        Task<string> GetWeatherData(string city,string countryCode);
    }
}
