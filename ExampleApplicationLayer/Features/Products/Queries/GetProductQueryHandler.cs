using System.ComponentModel.DataAnnotations;
using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Queries;

namespace ExampleApplicationLayer.Features.Products.Queries;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailsDto>
{
    private readonly List<ProductDetailsDto> _listOfProducts;

    public GetProductQueryHandler()
    {
        _listOfProducts = new List<ProductDetailsDto>
        {
            new ProductDetailsDto
            {
                Id = 1,
                Name = "Bottle of water",
                Price = 1.99M,
                Stock = 1000
            }
        };
    }
    public Task<ProductDetailsDto> HandleAsync(GetProductQuery query, CancellationToken cancellationToken = default)
    {
        if (query.Id <= 0)
        {
            throw new ValidationException("The Id must be greater than 0.");
        }
        var product = _listOfProducts.FirstOrDefault(p => p.Id == query.Id);
        if (product == null)
        {
            throw new ApplicationException($"Product with id {query.Id} was not found");
        }
        return Task.FromResult<ProductDetailsDto>(product);
    }
}