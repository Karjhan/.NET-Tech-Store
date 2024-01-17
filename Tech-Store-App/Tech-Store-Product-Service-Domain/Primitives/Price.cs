namespace Tech_Store_Product_Service_Domain.Primitives;

public sealed record Price()
{
    public decimal Amount { get; }

    public const string Currency = "DEFAULT";

    public Price(string? amount) : this()
    {
        if (amount is null)
        {
            // TODO: throw custom exception
        }else if (!decimal.TryParse(amount, out decimal result))
        {
            // TODO: throw custom exception
        }
        else
        {
            Amount = result;
        }
    }
}