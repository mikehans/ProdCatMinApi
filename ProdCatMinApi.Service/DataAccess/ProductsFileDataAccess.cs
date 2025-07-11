using System.Reflection;
using System.Text.Json;
using ProdCatMinApi.Service.Contracts;
using ProdCatMinApi.Service.Models;

namespace ProdCatMinApi.Service.DataAccess;

public class ProductsFileDataAccess : IProductsDataAccess
{
    List<Product> products = new List<Product>();

    public ProductsFileDataAccess()
    {
        string data = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataAccess", "catalog.json"));

        if (String.IsNullOrEmpty(data))
        {
            throw new FileLoadException("No data");
        }

        products = JsonSerializer.Deserialize<List<Product>>(data)
                    ?? throw new InvalidOperationException("Failed to parse JSON to List<Product>");        
    }

    public List<Product> GetAll()
    {
        return products;
    }

    public Product GetById(int id)
    {
        return products.Where(p => p.ProductId == id).FirstOrDefault() ?? new Product()
        {
            ProductId = 0
        };
    }

    public int InsertRecord(Product product)
    {
        products.Add(product);
        return 1;
    }

    // TODO: needs a better implementation (eg. taking a Func / Predicate param)
    public List<Product> Search(string property, string value)
    {
        List<Product> results = new();

        if (property.ToLower() == "brand")
        {
            results = products.Where(p => p.Brand == value).ToList();
        }
        else if (property.ToLower() == "name")
        {
            results = products.Where(p => p.Name == value).ToList();
        }

        return results;
    }
}
