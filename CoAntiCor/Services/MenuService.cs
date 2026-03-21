// /Services/Menu/MenuService.cs
using CoAntiCor.Data.Entities;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

using CoAntiCor.Services.Menu;

namespace CoAntiCor.Services;

public class MenuService : IMenuService
{
    private readonly CoAntiCorDbContext _db;

    public MenuService(CoAntiCorDbContext db) => _db = db;

    public async Task<List<MenuItem>> GetMenuAsync(string? role)
    {
        var query = _db.MenuItems
            .Where(m => m.IsActive)
            .OrderBy(m => m.DisplayOrder)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(role))
        {
            query = query.Where(m => m.Role == null || m.Role == role);
        }

        return await query.ToListAsync();
    }
}
