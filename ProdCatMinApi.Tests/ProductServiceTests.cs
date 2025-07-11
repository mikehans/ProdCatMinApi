using Microsoft.Extensions.Logging;
using ProdCatMinApi.Service;
using ProdCatMinApi.Service.DataAccess;
using ProdCatMinApi.Service.Contracts;
using ProdCatMinApi.Service.Models;

namespace ProdCatMinApi.Tests;

public class ProductServiceTests
{
    ProductsService sut;

    [SetUp]
    public void Setup()
    {
        sut = new ProductsService(new ProductsFileDataAccess());
    }

    [Test]
    public void GetAllProducts_ShouldReturnListofProducts()
    {
        List<Product> products = sut.GetAllProducts();

        Assert.That(products.Count(), Is.EqualTo(9));
    }

    [Test]
    public void GetProductByName_ShouldReturnAProduct()
    {
        List<Product> products = sut.GetProductsByName("Steel Ruler");

        Assert.That(products.Count(), Is.EqualTo(1));
        Assert.That(products[0].Brand, Is.EqualTo("Stanley"));
    }

    [Test]
    public void InsertProduct_ShouldAddRecordToDatabase()
    {
        var affectedRecords = sut.InsertProduct(new Product()
        {
            ProductId = 111,
            Brand = "ASDF",
            Name = "JUNK",
            Price = 111
        });

        Assert.That(affectedRecords, Is.EqualTo(1));
    }
}