using Hanabi.Results;

namespace Hanabi.Requests.Commands;

public interface ICommandHandler<in TCommand, TResult> where TCommand : class, ICommand<TResult>
{
    Task<IHanabiResult<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task<IHanabiResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}