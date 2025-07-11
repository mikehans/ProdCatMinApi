using System.Security.Claims;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ProdCatMinApi.Service;
using ProdCatMinApi.Service.Contracts;
using ProdCatMinApi.Service.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IProductsDataAccess, ProductsFileDataAccess>();

builder.AddOpenApiSetup();

var app = builder.Build();

app.ConfigureOpenApiForDevelopmentEnvironment();

app.UseHttpsRedirection();

app.AddProductRoutes();

app.Run();
