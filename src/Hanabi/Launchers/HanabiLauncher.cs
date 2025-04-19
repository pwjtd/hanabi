using Hanabi.Requests.Commands;
using Hanabi.Requests.Queries;
using Hanabi.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Launchers;

public class HanabiLauncher : IHanabiLauncher
{
    private readonly IServiceProvider _serviceProvider;
    public HanabiLauncher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }
    
    public async Task<IHanabiResult<TResult>> LaunchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));
                
        using var scope = _serviceProvider.CreateScope();
        var queryType = query.GetType();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
            
        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"There is no registered handler for query {queryType.Name}.");
            
        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
        if (method == null)
            throw new InvalidOperationException($"There is no HandleAsync method in handler for query {queryType.Name}.");
                
        try
        {
            return await (Task<IHanabiResult<TResult>>)method.Invoke(handler, new object[] { query, cancellationToken })!;
        }
        catch (Exception ex) when (ex is not InvalidOperationException && ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }
    
    public async Task<IHanabiResult<TResult>> LaunchCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));
                
        using var scope = _serviceProvider.CreateScope();
        var commandType = command.GetType();
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
            
        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"There is no registered handler for command {handlerType.Name}.");
            
        var method = handlerType.GetMethod(nameof(ICommandHandler<ICommand<TResult>, TResult>.HandleAsync));
        if (method == null)
            throw new InvalidOperationException($"There is no HandleAsync method in handler for command {commandType.Name}.");
                
        try
        {
            return await (Task<IHanabiResult<TResult>>)method.Invoke(handler, new object[] { command, cancellationToken })!;
        }
        catch (Exception ex) when (ex is not InvalidOperationException && ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }

    public async Task<IHanabiResult> LaunchQueryAsync(IQuery query, CancellationToken cancellationToken = default)
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));
                
        using var scope = _serviceProvider.CreateScope();
        var queryType = query.GetType();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType);
            
        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"There is no registered handler for query {queryType.Name}.");
            
        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery>.HandleAsync));
        if (method == null)
            throw new InvalidOperationException($"There is no HandleAsync method in handler for query {queryType.Name}.");
                
        try
        {
            return await (Task<IHanabiResult>)method.Invoke(handler, new object[] { query, cancellationToken })!;
        }
        catch (Exception ex) when (ex is not InvalidOperationException && ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }

    public async Task<IHanabiResult> LaunchCommandAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));
                
        using var scope = _serviceProvider.CreateScope();
        var commandType = command.GetType();
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            
        var handler = scope.ServiceProvider.GetService(handlerType);
        if (handler == null)
            throw new InvalidOperationException($"There is no registered handler for command {handlerType.Name}.");
            
        var method = handlerType.GetMethod(nameof(ICommandHandler<ICommand>.HandleAsync));
        if (method == null)
            throw new InvalidOperationException($"There is no HandleAsync method in handler for command {commandType.Name}.");
                
        try
        {
            return await (Task<IHanabiResult>)method.Invoke(handler, new object[] { command, cancellationToken })!;
        }
        catch (Exception ex) when (ex is not InvalidOperationException && ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }
}