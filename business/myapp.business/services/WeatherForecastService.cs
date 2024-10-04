using AutoMapper;
using Microsoft.Extensions.Logging;
using myapp.domain.models;
using myapp.domain.repositories;
using myapp.domain.services;
using myapp.infra.proxy.weatherforecast.adapters;
using myapp.infra.proxy.weatherforecast.clients;
using myapp.infra.proxy.weatherforecast.resources;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.business.services
{
    internal class WeatherForecastService(IWeatherApiAdapter weatherApiAdapter) : IWeatherForecastService
    {
        public async Task<WeatherForecast> GetCurrentWeatherAsync(double latitude, double longitude, string current, string hourly)
        {
            WeatherForecast forecast = await weatherApiAdapter.GetCurrentWeatherAsync(latitude, longitude, current, hourly);

            return forecast;
        }
    }
}
