// /Services/Menu/IMenuService.cs


using CoAntiCor.Data.Entities;

namespace CoAntiCor.Services.Menu;

public interface IMenuService
{
    Task<List<MenuItem>> GetMenuAsync(string? role);
}
