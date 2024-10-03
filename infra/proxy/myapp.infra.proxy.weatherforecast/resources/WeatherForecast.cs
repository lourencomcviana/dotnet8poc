namespace myapp.infra.proxy.weatherforecast.resources;


public class WeatherResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationtimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; }
    public string TimezoneAbbreviation { get; set; }
    public double Elevation { get; set; }
    public CurrentUnits CurrentUnits { get; set; }
    public CurrentWeather Current { get; set; }
    public HourlyUnits HourlyUnits { get; set; }
    public HourlyWeather Hourly { get; set; }
}

public class CurrentUnits
{
    public string Time { get; set; }
    public string Interval { get; set; }
    public string Temperature2m { get; set; }
    public string WindSpeed10m { get; set; }
}

public class CurrentWeather
{
    public string Time { get; set; }
    public int Interval { get; set; }
    public double Temperature2m { get; set; }
    public double WindSpeed10m { get; set; }
}

public class HourlyUnits
{
    public string Time { get; set; }
    public string Temperature2m { get; set; }
    public string RelativeHumidity2m { get; set; }
    public string WindSpeed10m { get; set; }
}

public class HourlyWeather
{
    public List<string> Time { get; set; }
    public List<double> Temperature2m { get; set; }
    public List<int> RelativeHumidity2m { get; set; }
    public List<double> WindSpeed10m { get; set; }
}