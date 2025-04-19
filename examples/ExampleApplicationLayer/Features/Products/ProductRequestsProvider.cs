using ExampleApplicationLayer.Features.Products.Commands.Create;
using ExampleApplicationLayer.Features.Products.Commands.Delete;
using ExampleApplicationLayer.Features.Products.Dtos;
using ExampleApplicationLayer.Features.Products.Queries.GetAll;
using ExampleApplicationLayer.Features.Products.Queries.GetProduct;
using Hanabi;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleApplicationLayer.Features.Products;

public static class ProductRequestsProvider
{
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {
        services.AddSingleton<ProductsCache>();
        services.LoadRequests(loader =>
        {
            loader.LoadHandler<GetProductQueryHandler>()
                .WithQuery<GetProductQuery>()
                .WithDataResult<ProductDetailsModel>();

            loader.LoadHandler<GetAllProductsQueryHandler>()
                .WithQuery<GetAllProductsQuery>()
                .WithDataResult<IEnumerable<ProductListItemModel>>();

            loader.LoadHandler<CreateProductCommandHandler>()
                .WithCommand<CreateProductCommand>()
                .WithDataResult<int?>();

            loader.LoadHandler<DeleteProductCommandHandler>()
                .WithCommand<DeleteProductCommand>()
                .WithoutDataResult();
        });
        return services;
    }
}