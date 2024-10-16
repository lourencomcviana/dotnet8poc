using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myapp.util.exceptions;
using myapp.util.functional;

namespace myapp.util.configuration;

public class ConfigurationHelper<T> (String optionName) where T : class
{
    public string OptionName => optionName;
    
    
    public Optional<T> Get(IConfiguration configuration)
    {
        var foundSection = GetSection(configuration);
        if (!foundSection.IsPresent())
        {
            Optional<T>.Empty();
        }

        var section = foundSection.Get();
        return Get(section);
    }
    
    public Optional<T> Get(IConfigurationSection section)
    {
        return  Optional<T>.Of(section.Get<T>()) ;
    }

    public Optional<IConfigurationSection> GetSection(IConfiguration configuration)
    {
        return Optional<IConfigurationSection>.Of(
            configuration.GetSection(OptionName)
        );
    }
}

public class ConfigurationHelperInjector<T> (String optionName) : ConfigurationHelper<T>(optionName)
    where T : class
{
    public Optional<T> Inject(IConfiguration configuration, IServiceCollection services)
    {
        var section = this
            .GetSection(configuration)
            .OrElseThrow(() => new InvalidConfigurationException(typeof(T))
            );
           
        services.Configure<T>(section);

        return Get(section);
    }
}
