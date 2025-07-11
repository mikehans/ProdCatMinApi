using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProdCatMinApi.Service.Models;

public class Product
{
    [JsonPropertyName("productId")]
    public int? ProductId { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; } = 0;
}