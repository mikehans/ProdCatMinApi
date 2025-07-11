using ProdCatMinApi.Service.Models;

namespace ProdCatMinApi.Service.Contracts;

public interface IProductsService
{
    List<Product> GetAllProducts();
    List<Product> GetProductsByName(string name);
    int InsertProduct(Product newProduct);
}
