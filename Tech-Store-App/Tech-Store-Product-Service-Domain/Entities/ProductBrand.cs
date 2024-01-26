using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class ProductBrand : Entity
{
    public Name Name { get; private set; }
    
    private ProductBrand(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public static ProductBrand Create(Guid id, Name name)
    {
        ProductBrand productBrand = new ProductBrand(id, name);

        return productBrand;
    }
}