using ExampleApplicationLayer.Features.Products.Commands.Create;
using ExampleApplicationLayer.Features.Products.Commands.Delete;
using ExampleApplicationLayer.Features.Products.Dtos;
using ExampleApplicationLayer.Features.Products.Queries.GetAll;
using ExampleApplicationLayer.Features.Products.Queries.GetProduct;
using Hanabi.Launchers;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IHanabiLauncher _hanabiLauncher;
    public ProductsController(IHanabiLauncher hanabiLauncher)
    {
        _hanabiLauncher = hanabiLauncher;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ProductDetailsModel> GetProductByIdAsync(int id)
    {
        var result = await _hanabiLauncher.LaunchQueryAsync(new GetProductQuery(id));
        return result.Data;
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<ProductListItemModel>> GetAllProductsAsync()
    {
        var result = await _hanabiLauncher.LaunchQueryAsync(new GetAllProductsQuery());
        return result.Data;
    }
    
    [HttpPost]
    public async Task<int?> AddProductAsync(CreateProductCommand command)
    {
        var result = await _hanabiLauncher.LaunchCommandAsync(command);
        return result.Data;
    }
    
        
    [HttpDelete("{id:int}")]
    public async Task<bool> AddProductAsync(int id)
    {
        var result = await _hanabiLauncher.LaunchCommandAsync(new DeleteProductCommand(id));
        return result.IsSuccess;
    }
}