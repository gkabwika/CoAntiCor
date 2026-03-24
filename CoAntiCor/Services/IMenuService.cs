// /Services/Menu/IMenuService.cs


using CoAntiCor.Core.Domain;

namespace CoAntiCor.Services.Menu;

public interface IMenuService
{
	Task<List<MenuItem>> GetMenuChildAsync(string? role, int? parentId);

	Task<List<MenuItem>> GetMenuAsync(string? role);
}
