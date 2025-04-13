using ExampleApplicationLayer.Features.Products.Dtos;
using ExampleApplicationLayer.Features.Products.Queries;
using Hanabi.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IQueryLauncher _queryLauncher;
    public ProductsController(IQueryLauncher queryLauncher)
    {
        _queryLauncher = queryLauncher;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ProductDetailsDto> GetProductByIdAsync(int id)
    {
        var dto = await _queryLauncher.LaunchQueryAsync(new GetProductQuery {Id = id});
        if (dto == null)
        {
            return null;
        }
        return dto;
    }
}