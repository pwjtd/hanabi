using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Requests.Queries;
using Hanabi.Results;

namespace ExampleApplicationLayer.Features.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductListItemModel>>
{
    private readonly ProductsCache _products;
    public GetAllProductsQueryHandler(ProductsCache products)
    {
        _products = products;
    }
    public Task<IHanabiResult<IEnumerable<ProductListItemModel>>> HandleAsync(GetAllProductsQuery productsQuery, CancellationToken cancellationToken = default)
    {
        var products = _products.GetAll();
        var result = new HanabiResult<IEnumerable<ProductListItemModel>>(true, [], MapProducts(products));
        return Task.FromResult<IHanabiResult<IEnumerable<ProductListItemModel>>>(result);
    }

    private IEnumerable<ProductListItemModel> MapProducts(IEnumerable<ProductDetailsModel> products)
    {
        return products.Select(x => new ProductListItemModel
        {
            Id = x.Id,
            Name = x.Name
        });
    }
    
}