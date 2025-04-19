using Hanabi.Loaders.Handlers.HandlerTypeSelectors;

namespace Hanabi.Loaders;

public interface IHanabiLoader
{
    HandlerTypeSelector<THandler> LoadHandler<THandler>() where THandler : class;
}