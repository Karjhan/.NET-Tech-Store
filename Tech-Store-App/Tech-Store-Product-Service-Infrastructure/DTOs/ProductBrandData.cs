using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class ProductBrandData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("Name")]
    public NameData Name { get; set; } = new NameData();
}