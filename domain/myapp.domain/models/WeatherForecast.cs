namespace myapp.domain.models;

public record WeatherForecast(
    string Time,
    int Interval,
    double Temperature2m,
    double WindSpeed10m)
{
    public int TemperatureF => 32 + (int)(Temperature2m / 0.5556);
}
