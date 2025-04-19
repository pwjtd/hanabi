namespace Hanabi.Results;

public class HanabiResult : IHanabiResult
{
    public bool IsSuccess { get; }
    public IReadOnlyList<string> Errors { get; }

    public HanabiResult(bool isSuccess, IEnumerable<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors?.ToList().AsReadOnly() ?? new List<string>().AsReadOnly();
    }

    public static HanabiResult Success() => new HanabiResult(true, new List<string>());
    public static HanabiResult Failure(IEnumerable<string> errors) => new HanabiResult(false, errors);
    public static HanabiResult Failure(string error) => Failure(new[] { error });
}

public class HanabiResult<T> : HanabiResult, IHanabiResult<T>
{
    public T Data { get; }

    public HanabiResult(bool isSuccess, IEnumerable<string> errors, T data) : base(isSuccess, errors)
    {
        Data = data;
    }

    public static HanabiResult<T> Success(T data) => new HanabiResult<T>(true, new List<string>(), data);
    public new static HanabiResult<T> Failure(IEnumerable<string> errors) => new HanabiResult<T>(false, errors, default);
    public new static HanabiResult<T> Failure(string error) => Failure(new[] { error });
}