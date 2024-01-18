namespace TeaHub.Server.Repositories
{
    public interface ITypeRepository
    {
        Task<List<Models.Domain.Type>> GetAllAsync();
        Task<Models.Domain.Type?> GetByIdAsync(Guid id);
        Task<Models.Domain.Type> CreateAsync(Models.Domain.Type type);
        Task<Models.Domain.Type?> UpdateAsync(Guid id, Models.Domain.Type type);
        Task<Models.Domain.Type?> DeleteAsync(Guid id);
    }
}
