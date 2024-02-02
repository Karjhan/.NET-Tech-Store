using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Domain.Abstractions;

public interface IVisualsRepository
{
    Task<Visuals?> GetByIdAsync(Guid id);

    void Update(Visuals visual);

    void Remove(Visuals visual);
}