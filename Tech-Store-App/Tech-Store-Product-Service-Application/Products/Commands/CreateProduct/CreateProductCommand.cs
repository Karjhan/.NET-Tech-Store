using Tech_Store_Product_Service_Application.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string ShortName,
    string ShortDescription,
    string MainPictureURL,
    string ProductTypeNameShort,
    string ProductGroupNameShort,
    string ProductBrandNameShort,
    List<string> PictureSources,
    List<string> SpecificationCategoryNames,
    Dictionary<string, Dictionary<string, string>> Specifications,
    string? LongName = default,
    string? LongDescription = default,
    string? PriceAmount = default,
    string? ProductTypeNameLong = default,
    string? ProductGroupNameLong = default,
    string? ProductBrandNameLong = default
): ICommand;