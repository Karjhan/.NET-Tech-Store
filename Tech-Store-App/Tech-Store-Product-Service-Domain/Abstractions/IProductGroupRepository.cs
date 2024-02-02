using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Domain.Abstractions;

public interface IProductGroupRepository
{
    Task<ProductGroup?> GetByIdAsync(Guid id);

    Task<List<ProductGroup>> GetAllAsync();
    
    void Add(ProductGroup group);

    void Update(ProductGroup group);

    void Remove(ProductGroup group);
}