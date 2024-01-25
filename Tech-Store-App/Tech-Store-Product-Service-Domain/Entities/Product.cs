using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Domain.Entities;

public sealed class Product : Entity
{
    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Price Price { get; private set; }

    public Visuals Visuals { get; private set; }

    public Guid VisualsId { get; private set; }

    public ProductType ProductType { get; private set; }

    public Guid ProductTypeId { get; private set; }

    public ProductBrand ProductBrand { get; private set; }

    public Guid ProductBrandId { get; private set; }
    
    public ProductGroup ProductGroup { get; private set; }

    public Guid ProductGroupId { get; private set; }
    
    public IEnumerable<ProductSpecification> Specifications { get; private set; }

    private Product(Guid id, Name name, Description description, Price price, Visuals visuals, Guid visualsId, ProductType productType, Guid productTypeId, ProductBrand productBrand, Guid productBrandId, ProductGroup productGroup, Guid productGroupId, IEnumerable<ProductSpecification> specifications) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Visuals = visuals;
        VisualsId = visualsId;
        ProductType = productType;
        ProductTypeId = productTypeId;
        ProductBrand = productBrand;
        ProductBrandId = productBrandId;
        ProductGroup = productGroup;
        ProductGroupId = productGroupId;
        Specifications = specifications;
    }

    public static Product Create (Guid id, Name name, Description description, Price price, Visuals visuals, Guid visualsId, ProductType productType, Guid productTypeId, ProductBrand productBrand, Guid productBrandId, ProductGroup productGroup, Guid productGroupId, IEnumerable<ProductSpecification> specifications)
    {
        Product product = new Product(id, name, description, price, visuals, visualsId, productType, productTypeId, productBrand, productBrandId, productGroup, productGroupId, specifications);

        return product;
    }
}