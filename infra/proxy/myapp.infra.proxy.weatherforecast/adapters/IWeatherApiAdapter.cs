using myapp.domain.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.infra.proxy.weatherforecast.adapters
{
    public interface IWeatherApiAdapter
    {
        public Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly);
    }
}
