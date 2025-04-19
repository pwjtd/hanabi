namespace Hanabi.Loaders.Handlers.ResultTypeSelectors;

public interface IResultTypeSelector<TRequest>
{
    void WithDataResult<TResultData>();
    void WithoutDataResult();
}