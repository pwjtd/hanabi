using Hanabi.Requests.Commands;

namespace ExampleApplicationLayer.Features.Products.Commands.Delete;

public record DeleteProductCommand(int Id) : ICommand;