using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class Visuals : Entity
{
    public string MainPictureURL { get; private set; }

    private List<string> PictureSources { get; }
    
    public Visuals(Guid productId, string mainPictureUrl) : base(productId)
    {
        if (string.IsNullOrEmpty(mainPictureUrl))
        {
            // TODO: throw custom exception
        }
        
        MainPictureURL = mainPictureUrl;
        
        PictureSources = new List<string> { MainPictureURL };
    }

    public IEnumerable<string> GetAllVisuals()
    {
        return PictureSources.AsReadOnly();
    }

    public void AddVisuals(string pictureUrl)
    {
        PictureSources.Add(pictureUrl);
    }

    public void AddVisuals(IEnumerable<string> pictureUrls)
    {
        PictureSources.AddRange(pictureUrls);
    }

    public void SetMainVisual(string pictureUrl)
    {
        MainPictureURL = pictureUrl;
    }

    public void RemoveVisual(string pictureUrl)
    {
        PictureSources.Remove(pictureUrl);
    }
}