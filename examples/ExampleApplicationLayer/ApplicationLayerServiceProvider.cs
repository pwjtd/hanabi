using ExampleApplicationLayer.Features.Products;
using Hanabi;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApplicationLayer;

public static class ApplicationLayerServiceProvider
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddHanabi();
        services.AddProducts();
        return services;
    }
}