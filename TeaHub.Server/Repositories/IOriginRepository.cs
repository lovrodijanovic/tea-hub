using TeaHub.Server.Models.Domain;

namespace TeaHub.Server.Repositories
{
    public interface IOriginRepository
    {
        Task<List<Origin>> GetAllAsync();
        Task<Origin?> GetByIdAsync(Guid id);
        Task<Origin> CreateAsync(Origin origin);
        Task<Origin?> UpdateAsync(Guid id, Origin origin);
        Task<Origin?> DeleteAsync(Guid id);
    }
}
