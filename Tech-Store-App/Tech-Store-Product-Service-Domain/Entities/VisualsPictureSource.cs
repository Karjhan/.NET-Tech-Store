using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public class VisualsPictureSource : Entity
{
    public string PictureURL { get; private set; }
    
    public VisualsPictureSource(Guid id) : base(id)
    {
        
    }
    
    public VisualsPictureSource(Guid visualsId, string pictureUrl) : base(visualsId)
    {
        if (string.IsNullOrEmpty(pictureUrl))
        {
            // TODO: throw custom exception
        }
        
        PictureURL = pictureUrl;
    }
}