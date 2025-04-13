namespace Hanabi.Queries;

public interface IQueryLauncher
{
    Task<TResult> LaunchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken token = default);
}