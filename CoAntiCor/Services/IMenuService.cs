// /Services/Menu/IMenuService.cs


using CoAntiCor.Core.Domain;

namespace CoAntiCor.Services.Menu;

public interface IMenuService
{
    Task<List<MenuItem>> GetMenuAsync(string? role);
}
