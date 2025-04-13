namespace Hanabi.Commands;

public interface ICommandLauncher
{
    Task LaunchCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand;
}