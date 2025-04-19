using Hanabi.Requests.Commands;
using Hanabi.Results;

namespace ExampleApplicationLayer.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly ProductsCache _products;
    public DeleteProductCommandHandler(ProductsCache products)
    {
        _products = products;
    }
    public Task<IHanabiResult> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
    {
        var productToDelete = _products.GetById(command.Id);
        _products.Delete(productToDelete);
        var result = new HanabiResult(true, []);
        return Task.FromResult<IHanabiResult>(result);
    }
}