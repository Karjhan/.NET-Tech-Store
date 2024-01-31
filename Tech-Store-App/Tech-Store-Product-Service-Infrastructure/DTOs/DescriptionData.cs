using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class DescriptionData
{
    [JsonPropertyName("ShortDescription")] 
    public string? ShortDescription { get; set; } = null!;

    [JsonPropertyName("LongDescription")]
    public string? LongDescription { get; set; } = null!;
}