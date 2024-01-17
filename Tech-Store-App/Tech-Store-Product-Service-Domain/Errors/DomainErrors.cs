using Tech_Store_Product_Service_Domain.Shared;

namespace Tech_Store_Product_Service_Domain.Errors;

public static class DomainErrors
{
    public static class Name
    {
        public static readonly Error InvalidShortName = new Error(
            "Name.InvalidShortName",
            "Shortname can't be null and must respect the shortname pattern."
        );
    }
}