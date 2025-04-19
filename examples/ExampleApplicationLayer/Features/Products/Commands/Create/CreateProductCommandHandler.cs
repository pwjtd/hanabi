using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Requests.Commands;
using Hanabi.Results;

namespace ExampleApplicationLayer.Features.Products.Commands.Create;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, int?>
{
    private readonly ProductsCache _products;
    public CreateProductCommandHandler(ProductsCache products)
    {
        _products = products;
    }
    public Task<IHanabiResult<int?>> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var productToAdd = new ProductDetailsModel
        {
            Name = command.Name,
            Stock = command.Stock,
            Price = command.Price,
        };
        var id = _products.Add(productToAdd);
        var result = new HanabiResult<int?>(true, [], id);
        return Task.FromResult<IHanabiResult<int?>>(result);
    }
}