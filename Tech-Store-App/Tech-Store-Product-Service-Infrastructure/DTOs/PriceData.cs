using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class PriceData
{
    [JsonPropertyName("Amount")] 
    public string? Amount { get; set; } = null!;
}