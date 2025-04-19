using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Requests.Queries;

namespace ExampleApplicationLayer.Features.Products.Queries.GetAll;

public record GetAllProductsQuery : IQuery<IEnumerable<ProductListItemModel>>;