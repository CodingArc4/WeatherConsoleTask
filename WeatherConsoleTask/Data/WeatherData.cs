using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsoleTask.Data
{
    public class WeatherData
    {
        public string City { get; set; }
        public string CountryCode { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; }
    }
}
