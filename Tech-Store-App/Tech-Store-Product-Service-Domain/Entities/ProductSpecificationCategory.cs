using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductSpecificationCategory : Entity
{
    public Name Name { get; set; }
    
    public ProductSpecificationCategory(Guid productTypeId, Name name) : base(productTypeId)
    {
        Name = name;
    }
}