using ProdCatMinApi.Service;
using ProdCatMinApi.Service.Contracts;
using ProdCatMinApi.Service.Models;

public static class ProductsRoutes
{
    private static IConfiguration _config;

    public static void AddProductRoutes(this WebApplication app)
    {
        _config = app.Configuration;

        app.MapGet("/products", GetAll)
            .WithName("GetAllProducts")
            .WithOpenApi();
        app.MapGet("products/{name}", Get);
        app.MapPost("products", Insert);
    }

    private static IResult GetAll(IProductsService svc)
    {
        List<Product> products = svc.GetAllProducts();

        if (products is null || products.Count() == 0)
        {
            return Results.NotFound();
        }
        else
        {
            return Results.Ok(products);
        }
    }

    private static IResult Get(string name, IProductsService svc)
    {
        List<Product> products = svc.GetProductsByName(name);

        if (products is null || products.Count() == 0)
        {
            return Results.NotFound();
        }
        else
        {
            return Results.Ok(products);
        }
       
    }

    private static IResult Insert(string name, string brand, decimal price, IProductsService svc)
    {
        Product product = new Product()
        {
            Name = name,
            Brand = brand,
            Price = price
        };
        int recordsCreated = svc.InsertProduct(product);
        
        return Results.Created();
    }
}
