namespace myapp.application.api.resources;
public record WeatherBody
(
    string Time,
    int Interval,
    double Temperature2m,
    double WindSpeed10m
);
