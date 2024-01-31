using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class ProductData
{
    [JsonPropertyName("Id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("Name")]
    public NameData Name { get; set; } = new NameData();
    
    [JsonPropertyName("Description")]
    public DescriptionData Description { get; set; } = new DescriptionData();
    
    [JsonPropertyName("Price")]
    public PriceData Price { get; set; } = new PriceData();
    
    [JsonPropertyName("VisualsId")]
    public string? VisualsId { get; set; }
    
    [JsonPropertyName("ProductTypeId")]
    public string? ProductTypeId { get; set; }
    
    [JsonPropertyName("ProductBrandId")]
    public string? ProductBrandId { get; set; }
    
    [JsonPropertyName("ProductGroupId")]
    public string? ProductGroupId { get; set; }

    [JsonPropertyName("Specifications")]
    public List<SpecificationData> Specifications { get; set; } = new List<SpecificationData>();

    [JsonPropertyName("Visuals")] 
    public VisualsData Visuals { get; set; } = new VisualsData();
}