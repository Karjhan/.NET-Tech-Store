using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Domain.Abstractions;

public interface IProductTypeRepository
{
    Task<ProductType?> GetByIdAsync(Guid id);

    Task<List<ProductType>> GetAllAsync();
    
    void Add(ProductType type);

    void Update(ProductType type);

    void Remove(ProductType type);
}