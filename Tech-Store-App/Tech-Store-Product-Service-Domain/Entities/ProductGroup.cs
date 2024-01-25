using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public class ProductGroup : Entity
{
    public Name Name { get; set; }

    public readonly List<ProductType> ProductTypes;
    
    private ProductGroup(Guid id, Name name, List<ProductType> productTypes) : base(id)
    {
        Name = name;
        ProductTypes = productTypes;
    }

    public static ProductGroup Create(Guid id, Name name, List<ProductType> productTypes)
    {
        ProductGroup productGroup = new ProductGroup(id, name, productTypes);

        return productGroup;
    }
}