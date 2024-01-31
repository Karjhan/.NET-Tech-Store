using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductSpecificationCategory : Entity
{
    public string Name { get; private set; }

    public ProductType ProductType { get; private set; }
    
    public ProductSpecificationCategory(Guid id) : base(id)
    {
        
    }
    
    public ProductSpecificationCategory(Guid productTypeId, ProductType productType, string name) : base(productTypeId)
    {
        Name = name;
        ProductType = productType;
    }
}