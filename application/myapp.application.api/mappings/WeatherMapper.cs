using AutoMapper;
using myapp.application.api.resources;
using myapp.domain.models;
using myapp.infra.proxy.weatherforecast.resources;

namespace myapp.application.api.mappings
{
    public class WeatherMapper
    {
        public class WeatherProfile : Profile
        {
            public WeatherProfile()
            {
                CreateMap<WeatherForecast, WeatherBody>()
                    .ConstructUsing(src => NewCurrentWeather(src));
            }

            private WeatherBody NewCurrentWeather(WeatherForecast weatherForecast)
            {
                return new WeatherBody(
                    Time: weatherForecast.Time,
                    Interval: weatherForecast.Interval,
                    Temperature2m: weatherForecast.Temperature2m,
                    WindSpeed10m: weatherForecast.WindSpeed10m
                    );
            }
        }
    }
}
