using System.ComponentModel.DataAnnotations;
using myapp.util.configuration;

namespace myapp.domain.configurations;

public class WeatherForecastOptions
{   
    [Required]
    public string Url { get; set; } 
    
    public double Latitude { get; set; } 

    public double Longitude { get; set; }

    public string Current { get; set; } = "temperature_2m,wind_speed_10m";
    public string Hourly { get; set; } = "temperature_2m,relative_humidity_2m,wind_speed_10m";
    
    
    public static ConfigurationHelper<WeatherForecastOptions> GetConfigurationHelper()
        => new ConfigurationHelper<WeatherForecastOptions>("WeatherForecast");
}

