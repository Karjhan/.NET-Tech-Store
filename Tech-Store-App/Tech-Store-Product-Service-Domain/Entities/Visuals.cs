using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class Visuals : Entity
{
    public string MainPictureURL { get; private set; }

    public List<VisualsPictureSource> PictureSources { get; }

    public Visuals(Guid id) : base(id)
    {
        
    }
    
    public Visuals(Guid productId, string mainPictureUrl) : base(productId)
    {
        if (string.IsNullOrEmpty(mainPictureUrl))
        {
            // TODO: throw custom exception
        }
        
        MainPictureURL = mainPictureUrl;
        
        PictureSources = new List<VisualsPictureSource> { new VisualsPictureSource(this.Id, MainPictureURL) };
    }
}