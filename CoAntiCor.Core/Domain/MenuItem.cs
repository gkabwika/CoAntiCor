namespace CoAntiCor.Data.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string TitleFrench { get; set; } = default!;
    public string Icon { get; set; } = default!; // e.g. "fa-solid fa-gauge"
    public string Url { get; set; } = default!;
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
    public int? ParentId { get; set; }
    public string? Role { get; set; }
}
