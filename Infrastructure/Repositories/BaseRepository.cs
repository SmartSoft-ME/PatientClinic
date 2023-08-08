using Application.IRepositories;
using SQLitePCL;
using System.Threading;

using Microsoft.EntityFrameworkCore;
using infrastructure;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PatientDbcontext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(PatientDbcontext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllEAsync(CancellationToken cancellationToken) => await _dbSet.ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) => await _dbSet.FindAsync(new object?[] { id },cancellationToken: cancellationToken) ?? throw new NotFoundException( id);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var Entity_To_Delete = await GetByIdAsync(id, cancellationToken);
            _dbSet.Remove(Entity_To_Delete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<TEntity>> ToList()
        {
            return await _dbSet.ToListAsync();
        }

    }
}