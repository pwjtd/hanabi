using ExampleApplicationLayer.Features.Products.Dtos;
using ExampleApplicationLayer.Features.Products.Queries;
using Hanabi;

namespace ExampleApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHanabi(loader =>
        {
            loader.LoadQuery<GetProductQuery, ProductDetailsDto, GetProductQueryHandler>();
        });
        builder.Services.AddControllers();

        
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}