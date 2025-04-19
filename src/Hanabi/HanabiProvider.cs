using Hanabi.Launchers;
using Hanabi.Loaders;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi;

public static class HanabiProvider
{
    public static IServiceCollection AddHanabi(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        services.AddSingleton<IHanabiLauncher, HanabiLauncher>();
        return services;
    }

    public static IServiceCollection LoadRequests(this IServiceCollection services, 
        Action<HanabiLoader> loaderConfiguration)
    {
        if (loaderConfiguration == null)
            throw new ArgumentNullException(nameof(loaderConfiguration));
        
        var loader = new HanabiLoader(services);
        loaderConfiguration(loader);
        return services;
    }
}