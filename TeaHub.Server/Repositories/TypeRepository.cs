
using Microsoft.EntityFrameworkCore;
using TeaHub.Server.Data;

namespace TeaHub.Server.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly TeaHubDbContext _dbContext;
        public TypeRepository(TeaHubDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<Models.Domain.Type> CreateAsync(Models.Domain.Type type)
        {
            await _dbContext.Types.AddAsync(type);
            await _dbContext.SaveChangesAsync();
            return type;
        }

        public async Task<Models.Domain.Type?> DeleteAsync(Guid id)
        {
            var existingType = await _dbContext.Types.FirstOrDefaultAsync(x => x.Id == id);

            if(existingType == null)
            {
                return null;
            }

            _dbContext.Types.Remove(existingType);
            await _dbContext.SaveChangesAsync();
            return existingType;
        }

        public async Task<List<Models.Domain.Type>> GetAllAsync()
        {
            return await _dbContext.Types.ToListAsync();
        }

        public async Task<Models.Domain.Type?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Types.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Domain.Type?> UpdateAsync(Guid id, Models.Domain.Type type)
        {
            var existingType = await _dbContext.Types.FirstOrDefaultAsync(x => x.Id == id);
            
            if(existingType == null) 
            { 
                return null;
            }

            existingType.Name = type.Name;
            await _dbContext.SaveChangesAsync();
            return existingType;
        }
    }
}
