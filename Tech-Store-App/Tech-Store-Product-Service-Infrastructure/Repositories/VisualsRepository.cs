using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.Repositories;

public class VisualsRepository : IVisualsRepository
{
    private readonly ApplicationContext _context;

    public VisualsRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public Task<Visuals?> GetByIdAsync(Guid id)
    {
        return _context.Visuals.SingleOrDefaultAsync(visual => visual.Id == id);
    }

    public void Update(Visuals visual)
    {
        _context.Visuals.Update(visual);
    }

    public void Remove(Visuals visual)
    {
        _context.Visuals.Remove(visual);
    }
}