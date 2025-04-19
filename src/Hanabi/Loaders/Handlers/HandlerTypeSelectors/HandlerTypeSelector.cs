using Hanabi.Loaders.Handlers.ResultTypeSelectors;
using Hanabi.Requests.Commands;
using Hanabi.Requests.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Loaders.Handlers.HandlerTypeSelectors;

public class HandlerTypeSelector<THandler> : IHandlerTypeSelector
{
    private readonly IServiceCollection _services;

    public HandlerTypeSelector(IServiceCollection services)
    {
        _services = services;
    }
    
    public IResultTypeSelector<TQuery> WithQuery<TQuery>()
    {
        return new ResultTypeSelector<THandler, TQuery>(_services, typeof(IQueryHandler<,>), typeof(IQueryHandler<>));
    }

    public IResultTypeSelector<TCommand> WithCommand<TCommand>()
    {
        return new ResultTypeSelector<THandler, TCommand>(_services, typeof(ICommandHandler<,>), typeof(ICommandHandler<>));
    }
}