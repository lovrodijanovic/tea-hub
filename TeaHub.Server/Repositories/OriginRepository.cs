using Microsoft.EntityFrameworkCore;
using TeaHub.Server.Data;
using TeaHub.Server.Models.Domain;

namespace TeaHub.Server.Repositories
{
    public class OriginRepository : IOriginRepository
    {
        private readonly TeaHubDbContext _dbContext;
        public OriginRepository(TeaHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Origin> CreateAsync(Origin origin)
        {
            await _dbContext.AddAsync(origin);
            await _dbContext.SaveChangesAsync();
            return origin;
        }

        public async Task<Origin?> DeleteAsync(Guid id)
        {
            var existingOrigin = await _dbContext.Origins.FirstOrDefaultAsync(x => x.Id == id);

            if (existingOrigin == null)
            {
                return null;
            }

            _dbContext.Origins.Remove(existingOrigin);
            await _dbContext.SaveChangesAsync(); 
            return existingOrigin;
        }

        public Task<List<Origin>> GetAllAsync()
        {
            return _dbContext.Origins.ToListAsync();
        }

        public async Task<Origin?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Origins.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Origin?> UpdateAsync(Guid id, Origin origin)
        {
            var existingOrigin = await _dbContext.Origins.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingOrigin == null)
            {
                return null;
            }

            existingOrigin.Name = origin.Name;
            await _dbContext.SaveChangesAsync();
            return existingOrigin;
        }
    }
}
