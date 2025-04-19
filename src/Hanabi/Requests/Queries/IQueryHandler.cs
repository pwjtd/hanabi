using Hanabi.Results;

namespace Hanabi.Requests.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<IHanabiResult<TResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<in TQuery> where TQuery : IQuery
{
    Task<IHanabiResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}