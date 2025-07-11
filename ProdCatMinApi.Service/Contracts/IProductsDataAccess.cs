using ProdCatMinApi.Service.Models;

namespace ProdCatMinApi.Service.Contracts;

public interface IProductsDataAccess
{
    int InsertRecord(Product product);
    List<Product> GetAll();
    Product GetById(int id);
    List<Product> Search(string property, string value);
}