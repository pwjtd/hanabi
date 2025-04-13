using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Queries;

namespace ExampleApplicationLayer.Features.Products.Queries;

public class GetProductQuery : IQuery<ProductDetailsDto>
{
    public int Id { get; set; }
}