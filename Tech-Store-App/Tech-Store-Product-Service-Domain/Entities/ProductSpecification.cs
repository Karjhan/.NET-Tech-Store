using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductSpecification : Entity
{
    public string Name { get; set; }
    
    public ProductSpecificationCategory Category { get; set; }

    public string Value { get; set; }
    
    public ProductSpecification(Guid productId, string name, ProductSpecificationCategory category, string value) : base(productId)
    {
        Name = name;
        Category = category;
        Value = value;
    }
}