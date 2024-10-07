using AutoMapper;
using myapp.domain.models;
using myapp.infra.proxy.weatherforecast.resources;

namespace myapp.infra.proxy.weatherforecast.mappings
{
    public class WeatherMapper
    {
        public class WeatherProfile : Profile
        {
            public WeatherProfile()
            {
                CreateMap<CurrentWeather, WeatherForecast>()
                    .ConstructUsing(src => NewCurrentWeather(src));
            }

            private WeatherForecast NewCurrentWeather(CurrentWeather currentWeather)
            {
                return new WeatherForecast(
                    Time: currentWeather.Time,
                    Interval: currentWeather.Interval,
                    Temperature2m: currentWeather.Temperature2m,
                    WindSpeed10m: currentWeather.WindSpeed10m
                    );
            }
        }
    }
}
