using Hanabi.Requests.Commands;

namespace ExampleApplicationLayer.Features.Products.Commands.Create;

public record CreateProductCommand(string Name, decimal Price, int Stock) : ICommand<int?>;