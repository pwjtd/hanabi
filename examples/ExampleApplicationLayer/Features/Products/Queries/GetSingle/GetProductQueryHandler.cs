using System.ComponentModel.DataAnnotations;
using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Requests;
using Hanabi.Requests.Queries;
using Hanabi.Results;

namespace ExampleApplicationLayer.Features.Products.Queries.GetProduct;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDetailsModel>
{
    private readonly ProductsCache _products;
    public GetProductQueryHandler(ProductsCache products)
    {
        _products = products;
    }
    public Task<IHanabiResult<ProductDetailsModel>> HandleAsync(GetProductQuery query, CancellationToken cancellationToken = default)
    {
        if (query.Id <= 0)
        {
            throw new ValidationException("The Id must be greater than 0.");
        }

        var product = _products.GetById(query.Id);
        if (product == null)
        {
            throw new ApplicationException($"Product with id {query.Id} was not found");
        }

        var result = new HanabiResult<ProductDetailsModel>(true, [], product);
        return Task.FromResult<IHanabiResult<ProductDetailsModel>>(result);
    }
}