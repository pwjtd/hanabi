using Hanabi.Requests.Commands;
using Hanabi.Requests.Queries;
using Hanabi.Results;

namespace Hanabi.Launchers;

public interface IHanabiLauncher
{
    Task<IHanabiResult<TResult>> LaunchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken token = default);
    Task<IHanabiResult<TResult>> LaunchCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    Task<IHanabiResult> LaunchQueryAsync(IQuery query, CancellationToken cancellationToken = default);
    Task<IHanabiResult> LaunchCommandAsync(ICommand command, CancellationToken cancellationToken = default);
}