using Microsoft.Extensions.DependencyInjection;

namespace Hanabi.Loaders.Handlers.ResultTypeSelectors;

public class ResultTypeSelector<THandler, TRequest> : IResultTypeSelector<TRequest>
{
    private readonly IServiceCollection _services;
    private readonly Type _handlerWithDataInterface;
    private readonly Type _handlerWithoutDataInterface;
    public ResultTypeSelector(IServiceCollection services, Type handlerWithDataInterface, Type handlerWithoutDataInterface)
    {
        _services = services;
        _handlerWithDataInterface = handlerWithDataInterface;
        _handlerWithoutDataInterface = handlerWithoutDataInterface;
    }
    public void WithDataResult<TResultData>()
    {
        var serviceType = _handlerWithDataInterface.MakeGenericType(typeof(TRequest), typeof(TResultData));
        _services.AddTransient(serviceType, typeof(THandler));
    }

    public void WithoutDataResult()
    {
        var serviceType = _handlerWithoutDataInterface.MakeGenericType(typeof(TRequest));
        _services.AddTransient(serviceType, typeof(THandler));
    }
}