namespace myapp.util.exceptions;

public class InvalidConfigurationException: InvalidOperationException
{
    public InvalidConfigurationException(Type type) : this("Configuration for " + type.Name + " is invalid.")
    {
    }

    public InvalidConfigurationException(string? message) : base(message)
    {
    }

    public InvalidConfigurationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}