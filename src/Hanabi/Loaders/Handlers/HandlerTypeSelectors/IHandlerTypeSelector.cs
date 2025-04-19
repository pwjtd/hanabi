using Hanabi.Loaders.Handlers.ResultTypeSelectors;
using Hanabi.Requests.Commands;
using Hanabi.Requests.Queries;

namespace Hanabi.Loaders.Handlers.HandlerTypeSelectors;

public interface IHandlerTypeSelector
{
    IResultTypeSelector<TQuery> WithQuery<TQuery>();
    IResultTypeSelector<TCommand> WithCommand<TCommand>();
}