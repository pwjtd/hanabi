using Hanabi.Commands;
using Hanabi.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi;

public static class HanabiProvider
{
    public static IServiceCollection AddHanabi(this IServiceCollection services,
        Action<HanabiLoader> loaderConfiguration)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
                
        if (loaderConfiguration == null)
            throw new ArgumentNullException(nameof(loaderConfiguration));
        
        var loader = new HanabiLoader(services);
        loaderConfiguration(loader);
        
        services.AddSingleton<ICommandLauncher, CommandLauncher>();
        services.AddSingleton<IQueryLauncher, QueryLauncher>();
        
        return services;
    }
}