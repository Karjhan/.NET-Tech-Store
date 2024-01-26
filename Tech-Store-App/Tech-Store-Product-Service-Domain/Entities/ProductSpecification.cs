using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductSpecification : Entity
{
    public string Name { get; private set; }
    
    public ProductSpecificationCategory Category { get; private set; }

    public string Value { get; private set; }
    
    public ProductSpecification(Guid productId, string name, ProductSpecificationCategory category, string value) : base(productId)
    {
        Name = name;
        Category = category;
        Value = value;
    }
}