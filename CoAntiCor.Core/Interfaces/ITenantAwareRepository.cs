
namespace CoAntiCor.Core.Interfaces
{
    public interface ITenantAwareRepository<TEntity>
      where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<TEntity>> ListAsync(CancellationToken ct = default);
        Task AddAsync(TEntity entity, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
