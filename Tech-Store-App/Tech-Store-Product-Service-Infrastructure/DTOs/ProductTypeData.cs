using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class ProductTypeData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("Name")]
    public NameData Name { get; set; } = new NameData();
    
    [JsonPropertyName("SpecificationCategories")]
    public List<string> SpecificationCategories { get; set; } = new List<string>();
}