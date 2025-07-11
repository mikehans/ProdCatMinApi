using ProdCatMinApi.Service.Contracts;
using ProdCatMinApi.Service.Models;
using ProdCatMinApi.Service.DataAccess;
using Microsoft.Extensions.Logging;

namespace ProdCatMinApi.Service;

public class ProductsService : IProductsService
{
    private readonly IProductsDataAccess dataAccess;

    public ProductsService(IProductsDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public List<Product> GetAllProducts()
    {
        return dataAccess.GetAll();
    }

    public List<Product> GetProductsByName(string productName)
    {
        return dataAccess.Search("name", productName);
    }

    public int InsertProduct(Product newProduct)
    {
        return dataAccess.InsertRecord(newProduct);
    }
}