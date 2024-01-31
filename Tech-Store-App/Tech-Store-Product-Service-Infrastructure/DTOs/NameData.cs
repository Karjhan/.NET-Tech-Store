using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class NameData
{
    [JsonPropertyName("ShortName")] 
    public string? ShortName { get; set; } = null!;

    [JsonPropertyName("LongName")]
    public string? LongName { get; set; } = null!;
}