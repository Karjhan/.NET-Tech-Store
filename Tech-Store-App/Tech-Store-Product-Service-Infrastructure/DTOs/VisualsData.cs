using System.Text.Json.Serialization;

namespace Tech_Store_Product_Service_Infrastructure.DTOs;

public class VisualsData
{
    [JsonPropertyName("MainPictureURL")] 
    public string? MainPictureURL { get; set; }

    [JsonPropertyName("PictureSources")] 
    public List<string> PictureSources { get; set; } = new List<string>();
}