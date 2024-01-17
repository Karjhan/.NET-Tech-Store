using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductType : Entity
{
    public Name Name { get; set; }
    
    private ProductType(Guid id, Name name) : base(id)
    {
        Name = name;
    }
    
    public static ProductType Create(Guid id, Name name)
    {
        ProductType productType = new ProductType(id, name);

        return productType;
    }
}