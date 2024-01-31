using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductSpecification : Entity
{
    public string Name { get; private set; }
    
    public ProductSpecificationCategory Category { get; private set; }

    public Guid ProductTypeId { get; private set; }
    
    public string CategoryName { get; private set; }

    public string Value { get; private set; }

    public ProductSpecification(Guid id) : base(id)
    {
        
    }
    
    public ProductSpecification(Guid productId, string name, ProductSpecificationCategory category, Guid productTypeId, string categoryName, string value) : base(productId)
    {
        Name = name;
        Category = category;
        ProductTypeId = productTypeId;
        CategoryName = categoryName;
        Value = value;
    }
}