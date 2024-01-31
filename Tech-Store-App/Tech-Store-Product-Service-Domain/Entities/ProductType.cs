using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductType : Entity
{
    public Name Name { get; private set; }

    public ProductGroup ProductGroup { get; private set; }

    public Guid ProductGroupId { get; private set; }

    public readonly List<ProductSpecificationCategory> SpecificationCategories = new List<ProductSpecificationCategory>();

    public ProductType(Guid id) : base(id)
    {
        
    }
    
    private ProductType(Guid id, Name name, List<ProductSpecificationCategory> specificationCategories, ProductGroup productGroup, Guid productGroupId) : base(id)
    {
        Name = name;
        SpecificationCategories = specificationCategories;
        ProductGroup = productGroup;
        ProductGroupId = productGroupId;
    }
    
    public static ProductType Create(Guid id, Name name, List<ProductSpecificationCategory> specificationCategories, ProductGroup productGroup, Guid productGroupId)
    {
        ProductType productType = new ProductType(id, name, specificationCategories, productGroup, productGroupId);

        return productType;
    }

    public void SetName(Name newName)
    {
        Name = newName;
    }

    public void SetGroup(ProductGroup newGroup)
    {
        ProductGroup = newGroup;
        ProductGroupId = newGroup.Id;
    }
}