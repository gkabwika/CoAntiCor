// /Services/Menu/MenuService.cs
using CoAntiCor.Core.Domain;
using CoAntiCor.Infrastructure.Context;
using CoAntiCor.Services.Menu;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.Services;

/// <summary>
/// Want me to generate?
/// I can also generate:
/// ✔ A dynamic Blazor sidebar that renders nested menus
/// ✔ A role‑aware menu loader(filters by user role)
/// ✔ A multilingual menu system(English/French)
/// ✔ A menu management admin page(CRUD)
/// ✔ A permissions matrix for menu visibility
/// </summary>
public class MenuService : IMenuService
{
    private readonly CoAntiCorDbContext _db;

    public MenuService(CoAntiCorDbContext db) => _db = db;

    
    public async Task<List<MenuItem>> GetMenuAsync(string? role)
    {
        var menu = _db.MenuItems
            .Where(m => m.IsActive)
            .OrderBy(m => m.DisplayOrder)
            .AsQueryable();

        var topLevel = menu.Where(m => m.ParentId == null);
        var children = menu.Where(m => m.ParentId != null);

        if (!string.IsNullOrWhiteSpace(role))
        {
            topLevel = topLevel.Where(m => m.Role == null || m.Role == role);
        }

        return await topLevel.ToListAsync();
    }

    public async Task<List<MenuItem>> GetMenuChildAsync(string? role, int? parentId)
    {
        var menu = _db.MenuItems
            .Where(m => m.IsActive)
            .OrderBy(m => m.DisplayOrder)
            .AsQueryable();

        var children = menu.Where(m => m.ParentId != null && m.ParentId != parentId);

        if (!string.IsNullOrWhiteSpace(role))
        {
            children = children.Where(m => m.Role == null || m.Role == role);
        }

        return await children.ToListAsync();
    }
}
