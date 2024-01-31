using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Domain.Primitives;
using Tech_Store_Product_Service_Infrastructure.Configuration;
using Tech_Store_Product_Service_Infrastructure.DataContexts;
using Tech_Store_Product_Service_Infrastructure.DTOs;

namespace Tech_Store_Product_Service_Infrastructure.SeedData.Initializer;

public class DataContextSeed(IOptions<SeedDataConfiguration> seedOptions) : IDataContextSeed
{
    private readonly SeedDataConfiguration _options = seedOptions.Value ?? throw new ArgumentException("Invalid seed options");

    public async Task SeedAsync(ApplicationContext context, IHostEnvironment environment)
    {
        // Establish source path for seed data json files
        string mainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + _options.BaseDirectory;
        
        List<ProductBrand> productBrands = new List<ProductBrand>();
        List<ProductType> productTypes = new List<ProductType>();
        List<ProductSpecificationCategory> productSpecificationCategories = new List<ProductSpecificationCategory>();
        List<ProductGroup> productGroups = new List<ProductGroup>();
        List<Visuals> productVisualsList = new List<Visuals>();
        List<ProductSpecification> productSpecificationsList = new List<ProductSpecification>();
        List<Product> products = new List<Product>();
        List<VisualsPictureSource> pictureSources = new List<VisualsPictureSource>();

        // Seed the brands
        if (!context.ProductBrands.Any())
        {
            string productBrandsResource = await File.ReadAllTextAsync(mainPath + _options.Brands);
            try
            {
                JsonDocument productBrandsDocument = JsonDocument.Parse(productBrandsResource);
                foreach (var productBrandElement in productBrandsDocument.RootElement.EnumerateArray())
                {
                    // Get data from json
                    ProductBrandData productBrandData = new ProductBrandData();
                    productBrandData.Id = productBrandElement.TryGetProperty(nameof(productBrandData.Id), out var productBrandIdValue) 
                        ? productBrandIdValue.ToString() 
                        : default;
                    if (productBrandElement.TryGetProperty(nameof(productBrandData.Name), out var productBrandNameValue))
                    {
                        productBrandData.Name.ShortName = productBrandNameValue.TryGetProperty(nameof(productBrandData.Name.ShortName), out var productBrandShortNameValue) 
                            ? productBrandShortNameValue.ToString() 
                            : default;
                        productBrandData.Name.LongName = productBrandNameValue.TryGetProperty(nameof(productBrandData.Name.LongName), out var productBrandLongNameValue) 
                            ? productBrandLongNameValue.ToString() 
                            : default;
                    }
                    
                    // Establish entity
                    ProductBrand result = ProductBrand.Create(
                        new Guid(productBrandData.Id),
                        new Name(productBrandData.Name.ShortName, productBrandData.Name.LongName)
                    );
                    productBrands.Add(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            // Add data
            context.ProductBrands.AddRange(productBrands);
        }

        // Seed the types and specification categories
        if (!context.ProductTypes.Any() || !context.ProductSpecificationCategoriesCategories.Any())
        {
            string productTypesResource = await File.ReadAllTextAsync(mainPath + _options.Types);
            try
            {
                JsonDocument productTypesDocument = JsonDocument.Parse(productTypesResource);
                foreach (var productTypeElement in productTypesDocument.RootElement.EnumerateArray())
                {
                    // Get data from json
                    ProductTypeData productTypeData = new ProductTypeData();
                    productTypeData.Id = productTypeElement.TryGetProperty(nameof(productTypeData.Id), out var productTypeIdValue) 
                        ? productTypeIdValue.ToString() 
                        : default;
                    if (productTypeElement.TryGetProperty(nameof(productTypeData.Name), out var productTypeNameValue))
                    {
                        productTypeData.Name.ShortName = productTypeNameValue.TryGetProperty(nameof(productTypeData.Name.ShortName), out var productTypeShortNameValue) 
                            ? productTypeShortNameValue.ToString() 
                            : default;
                        productTypeData.Name.LongName = productTypeNameValue.TryGetProperty(nameof(productTypeData.Name.LongName), out var productTypeLongNameValue) 
                            ? productTypeLongNameValue.ToString() 
                            : default;
                    }
                    if (productTypeElement.TryGetProperty(nameof(productTypeData.SpecificationCategories), out var productTypeSpecificationCategoriesValue))
                    {
                        foreach (var element in productTypeSpecificationCategoriesValue.EnumerateArray())
                        {
                            productTypeData.SpecificationCategories.Add(element.ToString());
                        }
                    }
                    
                    // Establish entity
                    ProductType typeResult = new ProductType(new Guid(productTypeData.Id));
                    List<ProductSpecificationCategory> categoriesResult = productTypeData.SpecificationCategories.
                        Select(categoryName => new ProductSpecificationCategory(typeResult.Id, typeResult, categoryName)).ToList();
                    typeResult.SpecificationCategories.AddRange(categoriesResult);
                    typeResult.SetName(new Name(productTypeData.Name.ShortName, productTypeData.Name.LongName));
                    productTypes.Add(typeResult);
                    productSpecificationCategories.AddRange(categoriesResult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            //Add data
            context.ProductTypes.AddRange(productTypes);
            context.ProductSpecificationCategoriesCategories.AddRange(productSpecificationCategories);
        }
        
        // Seed the product groups
        if (!context.ProductGroups.Any())
        {
            string productGroupsResource = await File.ReadAllTextAsync(mainPath + _options.Groups);
            try
            {
                JsonDocument productGroupsDocument = JsonDocument.Parse(productGroupsResource);
                foreach (var productGroupElement in productGroupsDocument.RootElement.EnumerateArray())
                {
                    // Get data from json
                    ProductGroupData productGroupData = new ProductGroupData();
                    productGroupData.Id = productGroupElement.TryGetProperty(nameof(productGroupData.Id), out var productGroupIdValue) 
                        ? productGroupIdValue.ToString() 
                        : default;
                    if (productGroupElement.TryGetProperty(nameof(productGroupData.Name), out var productGroupNameValue))
                    {
                        productGroupData.Name.ShortName = productGroupNameValue.TryGetProperty(nameof(productGroupData.Name.ShortName), out var productGroupShortNameValue) 
                            ? productGroupShortNameValue.ToString() 
                            : default;
                        productGroupData.Name.LongName = productGroupNameValue.TryGetProperty(nameof(productGroupData.Name.LongName), out var productGroupLongNameValue) 
                            ? productGroupLongNameValue.ToString() 
                            : default;
                    }
                    if (productGroupElement.TryGetProperty(nameof(productGroupData.ProductTypes), out var productGroupTypesValue))
                    {
                        foreach (var element in productGroupTypesValue.EnumerateArray())
                        {
                            productGroupData.ProductTypes.Add(element.ToString());
                        }
                    }
                    
                    // Establish entity
                    List<ProductType> typesList = productTypes
                        .Where(productType => productGroupData.ProductTypes.Contains(productType.Id.ToString()))
                        .ToList();
                    ProductGroup groupResult = ProductGroup.Create(
                        new Guid(productGroupData.Id),
                        new Name(productGroupData.Name.ShortName, productGroupData.Name.LongName),
                        typesList
                    );
                    foreach (var productType in typesList)
                    {
                        productType.SetGroup(groupResult);
                    }
                    productGroups.Add(groupResult);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            // Add data
            context.ProductGroups.AddRange(productGroups);
        }
        
        // Seed the products
        if (!context.Products.Any() || !context.Visuals.Any() || !context.ProductSpecifications.Any())
        {
            string productsResource = await File.ReadAllTextAsync(mainPath + _options.Products);
            try
            {
                JsonDocument productsDocument = JsonDocument.Parse(productsResource);
                foreach (var productElement in productsDocument.RootElement.EnumerateArray())
                {
                    // Get data from json
                    ProductData productData = new ProductData();
                    productData.Id = productElement.TryGetProperty(nameof(productData.Id), out var productIdValue) 
                        ? productIdValue.ToString() 
                        : default;
                    if (productElement.TryGetProperty(nameof(productData.Name), out var productNameValue))
                    {
                        productData.Name.ShortName = productNameValue.TryGetProperty(nameof(productData.Name.ShortName), out var productShortNameValue) 
                            ? productShortNameValue.ToString() 
                            : default;
                        productData.Name.LongName = productNameValue.TryGetProperty(nameof(productData.Name.LongName), out var productLongNameValue) 
                            ? productLongNameValue.ToString() 
                            : default;
                    }
                    if (productElement.TryGetProperty(nameof(productData.Description), out var productDescriptionValue))
                    {
                        productData.Description.ShortDescription = productDescriptionValue.TryGetProperty(nameof(productData.Description.ShortDescription), out var productShortDescriptionValue) 
                            ? productShortDescriptionValue.ToString() 
                            : default;
                        productData.Description.LongDescription = productDescriptionValue.TryGetProperty(nameof(productData.Description.LongDescription), out var productLongDescriptionValue) 
                            ? productLongDescriptionValue.ToString() 
                            : default;
                    }
                    if (productElement.TryGetProperty(nameof(productData.Price), out var productPriceValue))
                    {
                        productData.Price.Amount = productPriceValue.TryGetProperty(nameof(productData.Price.Amount), out var productPriceAmountValue) 
                            ? productPriceAmountValue.ToString() 
                            : default;
                    }
                    productData.VisualsId = productElement.TryGetProperty(nameof(productData.VisualsId), out var productVisualsIdValue) 
                        ? productVisualsIdValue.ToString() 
                        : default;
                    productData.ProductTypeId = productElement.TryGetProperty(nameof(productData.ProductTypeId), out var productProductTypeIdValue) 
                        ? productProductTypeIdValue.ToString() 
                        : default;
                    productData.ProductBrandId = productElement.TryGetProperty(nameof(productData.ProductBrandId), out var productProductBrandIdValue) 
                        ? productProductBrandIdValue.ToString() 
                        : default;
                    productData.ProductGroupId = productElement.TryGetProperty(nameof(productData.ProductGroupId), out var productProductGroupIdValue) 
                        ? productProductGroupIdValue.ToString() 
                        : default;
                    if (productElement.TryGetProperty(nameof(productData.Specifications), out var productSpecificationsValue))
                    {
                        foreach (var element in productSpecificationsValue.EnumerateArray())
                        {
                            var specificationData = new SpecificationData();
                            specificationData.Name = element.TryGetProperty(nameof(specificationData.Name), out var specificationNameValue) 
                                ? specificationNameValue.ToString() 
                                : default;
                            specificationData.Category = element.TryGetProperty(nameof(specificationData.Category), out var specificationCategoryValue) 
                                ? specificationCategoryValue.ToString() 
                                : default;
                            specificationData.Value = element.TryGetProperty(nameof(specificationData.Value), out var specificationValue) 
                                ? specificationValue.ToString() 
                                : default;
                            productData.Specifications.Add(specificationData);
                        }
                    }
                    if (productElement.TryGetProperty(nameof(productData.Visuals), out var productVisualsValue))
                    {
                        productData.Visuals.MainPictureURL = productVisualsValue.TryGetProperty(nameof(productData.Visuals.MainPictureURL), out var productVisualsMainValue) 
                            ? productVisualsMainValue.ToString() 
                            : default;
                        if(productVisualsValue.TryGetProperty(nameof(productData.Visuals.PictureSources), out var productVisualsSourcesValue))
                        {
                            foreach (var element in productVisualsSourcesValue.EnumerateArray())
                            {
                                productData.Visuals.PictureSources.Add(element.ToString());
                            }
                        }
                    }
                    
                    // Establish entity
                    var productId = new Guid(productData.Id);
                    var productName = new Name(productData.Name.ShortName, productData.Name.LongName);
                    var productDescription = new Description(productData.Description.ShortDescription, productData.Description.LongDescription);
                    var productPrice = new Price(productData.Price.Amount);
                    var productTypeId = new Guid(productData.ProductTypeId);
                    var productType = productTypes.FirstOrDefault(type => type.Id == productTypeId);
                    var productBrandId = new Guid(productData.ProductBrandId);
                    var productBrand = productBrands.FirstOrDefault(brand => brand.Id == productBrandId);
                    var productGroupId = new Guid(productData.ProductGroupId);
                    var productGroup = productGroups.FirstOrDefault(group => group.Id == productGroupId); 
                    var productVisuals = new Visuals(new Guid(productData.VisualsId), productData.Visuals.MainPictureURL);
                    productVisuals.PictureSources.AddRange(productData.Visuals.PictureSources.Select(picUri => new VisualsPictureSource(productVisuals.Id, picUri)));
                    productVisualsList.Add(productVisuals);
                    pictureSources.AddRange(productVisuals.PictureSources);
                    var productSpecifications = productData.Specifications.Select(spec =>
                    {
                        var specCategory = productSpecificationCategories.FirstOrDefault(specCat =>
                            specCat.Name == spec.Category && specCat.Id.ToString() == productData.ProductTypeId);
                        return new ProductSpecification(productId, spec.Name, specCategory, productTypeId, spec.Category, spec.Value);
                    }).ToList();
                    productSpecificationsList.AddRange(productSpecifications);
                    var product = Product.Create(
                        productId,
                        productName,
                        productDescription,
                        productPrice,
                        productVisuals,
                        productType,
                        productTypeId,
                        productBrand,
                        productBrandId,
                        productGroup,
                        productGroupId,
                        productSpecifications
                    );
                    products.Add(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            // Add data
            context.Visuals.AddRange(productVisualsList);
            context.ProductSpecifications.AddRange(productSpecificationsList);
            context.Products.AddRange(products);
            context.PictureSources.AddRange(pictureSources);
        }
        
        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }
    }
}