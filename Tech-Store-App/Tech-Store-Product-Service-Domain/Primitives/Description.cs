using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Store_Product_Service_Domain.Primitives;

[ComplexType]
public sealed record Description()
{
    public string ShortDescription { get; init; } = null!;

    public string? LongDescription { get; init; }

    public Description(string? shortDescription, string? longDescription) : this()
    {
        LongDescription = longDescription;
        
        if (string.IsNullOrEmpty(shortDescription))
        {
            // TODO: throw custom exception
        }

        ShortDescription = shortDescription!;
    }
}