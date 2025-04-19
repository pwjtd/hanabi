namespace Hanabi.Results;

public interface IHanabiResult
{
    bool IsSuccess { get; }
    IReadOnlyList<string> Errors { get; }
}

public interface IHanabiResult<out T> : IHanabiResult
{
    T Data { get; }
}
