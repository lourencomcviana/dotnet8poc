using myapp.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.domain.services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly);
    }
}
