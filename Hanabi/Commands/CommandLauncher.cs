using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Commands;

internal class CommandLauncher : ICommandLauncher
{
    private readonly IServiceProvider _serviceProvider;
        
    public CommandLauncher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public async Task LaunchCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));
                
        using var scope = _serviceProvider.CreateScope();
            
        var handler = scope.ServiceProvider.GetService<ICommandHandler<TCommand>>();
        if (handler == null)
            throw new InvalidOperationException($"There is no registered handler for command {typeof(TCommand).Name}.");
                
        try
        {
            await handler.HandleAsync(command, cancellationToken);
        }
        catch (Exception ex) when (ex.InnerException != null)
        {
            throw ex.InnerException;
        }
    }
}