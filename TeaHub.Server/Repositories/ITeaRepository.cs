using System.Security;
using TeaHub.Server.Models.Domain;

namespace TeaHub.Server.Repositories
{
    public interface ITeaRepository
    {
        Task<Tea> CreateAsync(Tea tea);
        Task<List<Tea>> GetAllAsync();
        Task<Tea?> GetByIdAsync(Guid id);
        Task<Tea?> UpdateAsync(Tea tea, Guid id);
        Task<Tea?> DeleteAsync(Guid id);
    }
}
