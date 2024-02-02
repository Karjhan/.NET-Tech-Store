using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Domain.Abstractions;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);

    Task<List<Product>> GetAllAsync();
    
    void Add(Product product);

    void Update(Product product);

    void Remove(Product product);
}