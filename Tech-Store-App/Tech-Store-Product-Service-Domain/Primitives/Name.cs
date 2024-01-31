using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Tech_Store_Product_Service_Domain.Primitives;

[ComplexType]
public sealed record Name()
{
    public string ShortName { get; init; } = null!;

    public string? LongName { get; init; }

    public Name(string shortName, string? longName = "") : this()
    {
        LongName = longName;

        if (!IsValidName(shortName))
        {
            // TODO: throw custom exception
        }
        
        ShortName = shortName;
    }

    private static bool IsValidName(string? name)
    {
        return !string.IsNullOrEmpty(name) && Regex.IsMatch(name, "^[A-Z].{5,}$");
    }
}