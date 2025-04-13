using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Queries;

internal class QueryLauncher : IQueryLauncher
{
    private readonly IServiceProvider _serviceProvider;
        
    public QueryLauncher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }
    
    public async Task<TResult> LaunchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
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
            throw new InvalidOperationException($"There is no HandleAsync method in handlerz for query {queryType.Name}.");
                
        try
        {
            return await (Task<TResult>)method.Invoke(handler, new object[] { query, cancellationToken })!;
        }
        catch (Exception ex) when (ex is not InvalidOperationException && ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }
}