using Hanabi.Commands;
using Hanabi.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi;

public class HanabiLoader
{
    private readonly IServiceCollection _services;
        
    public HanabiLoader(IServiceCollection services)
    {
        _services = services;
    }
        
    public HanabiLoader LoadCommand<TCommand, THandler>()
        where TCommand : class, ICommand
        where THandler : class, ICommandHandler<TCommand>
    {
        _services.AddTransient<ICommandHandler<TCommand>, THandler>();
        return this;
    }
        
    public HanabiLoader LoadQuery<TQuery, TResult, THandler>()
        where TQuery : class, IQuery<TResult>
        where THandler : class, IQueryHandler<TQuery, TResult>
    {
        _services.AddTransient<IQueryHandler<TQuery, TResult>, THandler>();
        return this;
    }
}