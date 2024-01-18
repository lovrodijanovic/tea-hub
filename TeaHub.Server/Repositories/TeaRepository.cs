using Microsoft.EntityFrameworkCore;
using TeaHub.Server.Data;
using TeaHub.Server.Models.Domain;

namespace TeaHub.Server.Repositories
{
    public class TeaRepository : ITeaRepository
    {
        private readonly TeaHubDbContext _dbContext;

        public TeaRepository(TeaHubDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Tea> CreateAsync(Tea tea)
        {
            await _dbContext.Teas.AddAsync(tea);
            await _dbContext.SaveChangesAsync();
            return tea;
        }

        public async Task<Tea?> DeleteAsync(Guid id)
        {
            var existingTea = await _dbContext.Teas.FirstOrDefaultAsync(x => x.Id == id);
            
            if(existingTea == null)
            {
                return null;
            }

            _dbContext.Teas.Remove(existingTea);
            await _dbContext.SaveChangesAsync();
            return existingTea;
        }

        public async Task<List<Tea>> GetAllAsync()
        {
            return await _dbContext.Teas.Include("Type").Include("Origin").ToListAsync();
        }

        public async Task<Tea?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Teas
                .Include("Type")
                .Include("Origin")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tea?> UpdateAsync(Tea tea, Guid id)
        {
            var existingTea = await _dbContext.Teas.FirstOrDefaultAsync(x => x.Id == id);

            if(existingTea == null)
            {
                return null;
            }

            existingTea.Name = tea.Name;
            existingTea.About = tea.About;
            existingTea.PurchasedFrom = tea.PurchasedFrom;
            existingTea.Score = tea.Score;
            existingTea.OriginId = tea.OriginId;
            existingTea.TypeId = tea.TypeId;

            await _dbContext.SaveChangesAsync();

            return existingTea;
        }
    }
}
