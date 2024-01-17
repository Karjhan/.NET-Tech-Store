namespace Tech_Store_Product_Service_Domain.Primitives;

public sealed record Description()
{
    public string ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public Description(string? shortDescription, string? longDescription, int charLimitForShortDesc) : this()
    {
        LongDescription = longDescription;
        
        if (string.IsNullOrEmpty(shortDescription))
        {
            // TODO: throw custom exception
        }else if (shortDescription.Length < charLimitForShortDesc)
        {
            // TODO: throw custom exception
        }

        ShortDescription = shortDescription;
    }
}