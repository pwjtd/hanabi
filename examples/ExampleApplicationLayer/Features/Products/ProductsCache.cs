using ExampleApplicationLayer.Features.Products.Dtos;

namespace ExampleApplicationLayer.Features.Products;

public class ProductsCache
{
    private readonly List<ProductDetailsModel> _products;

    public ProductsCache()
    {
        _products = new List<ProductDetailsModel>()
        {
            new()
            {
                Id = 1,
                Name = "Bottle of water",
                Price = 1.99M,
                Stock = 1000
            }
        };
    }

    public IEnumerable<ProductDetailsModel> GetAll()
    {
        return _products;
    }

    public ProductDetailsModel? GetById(int id)
    {
        return _products.SingleOrDefault(p => p.Id == id);
    }

    public int? Add(ProductDetailsModel product)
    {
        if (product != null)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product.Id;
        }

        return null;
    }
    
    public void Delete(ProductDetailsModel product)
    {
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}