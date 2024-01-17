using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class Product : Entity
{
    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Price Price { get; private set; }

    public ProductVisuals Visuals { get; private set; }

    public ProductType ProductType { get; private set; }

    public int ProductTypeId { get; private set; }

    public ProductBrand ProductBrand { get; private set; }

    public int ProductBrandId { get; private set; }

    private Product(Guid id, Name name, Description description, Price price, ProductVisuals visuals, ProductType productType, int productTypeId, ProductBrand productBrand, int productBrandId) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Visuals = visuals;
        ProductType = productType;
        ProductTypeId = productTypeId;
        ProductBrand = productBrand;
        ProductBrandId = productBrandId;
    }

    public static Product Create (Guid id, Name name, Description description, Price price, ProductVisuals visuals, ProductType productType, int productTypeId, ProductBrand productBrand, int productBrandId)
    {
        Product product = new Product(id, name, description, price, visuals, productType, productTypeId, productBrand, productBrandId);

        return product;
    }
}