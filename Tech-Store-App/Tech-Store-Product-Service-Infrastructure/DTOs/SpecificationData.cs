using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class SpecificationData
{
    [JsonPropertyName("Name")] 
    public string? Name { get; set; } = null!;
    
    [JsonPropertyName("Category")] 
    public string? Category { get; set; } = null!;
    
    [JsonPropertyName("Value")] 
    public string? Value { get; set; } = null!;
}