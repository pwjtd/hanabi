using Hanabi.Loaders.Handlers.HandlerTypeSelectors;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Loaders;

public class HanabiLoader : IHanabiLoader
{
    private readonly IServiceCollection _services;

    public HanabiLoader(IServiceCollection services)
    {
        _services = services;
    }
    
    public HandlerTypeSelector<THandler> LoadHandler<THandler>() where THandler : class
    {
        return new HandlerTypeSelector<THandler>(_services);
    }
}
