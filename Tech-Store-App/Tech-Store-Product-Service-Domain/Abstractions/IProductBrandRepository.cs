using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Domain.Abstractions;

public interface IProductBrandRepository
{
    Task<ProductBrand?> GetByIdAsync(Guid id);

    Task<List<ProductBrand>> GetAllAsync();
    
    void Add(ProductBrand brand);

    void Update(ProductBrand brand);

    void Remove(ProductBrand brand);
}