using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductType : Entity
{
    public Name Name { get; set; }

    public readonly IEnumerable<ProductSpecificationCategory> SpecificationCategories;
    
    private ProductType(Guid id, Name name, IEnumerable<ProductSpecificationCategory> specificationCategories) : base(id)
    {
        Name = name;
        SpecificationCategories = specificationCategories;
    }
    
    public static ProductType Create(Guid id, Name name, IEnumerable<ProductSpecificationCategory> specificationCategories)
    {
        ProductType productType = new ProductType(id, name, specificationCategories);

        return productType;
    }
}