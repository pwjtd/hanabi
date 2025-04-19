using ExampleApplicationLayer.Features.Products.Dtos;
using Hanabi.Requests.Queries;

namespace ExampleApplicationLayer.Features.Products.Queries.GetProduct;

public record GetProductQuery(int Id) : IQuery<ProductDetailsModel>;