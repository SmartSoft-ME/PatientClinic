using Application.IRepositories;
using SQLitePCL;
using System.Threading;
using PatientClinic;
using Microsoft.EntityFrameworkCore;
using infrastructure;

namespace Infrastructure.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PatientDbcontext _context;
        private readonly DbSet<TEntity> _dbset;

        public BaseRepository(PatientDbcontext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllEAsync(CancellationToken cancellationToken) => await _dbset.ToListAsync(cancellationToken);
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) => await _dbset.FindAsync(new object?[] { id }, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var Entity_To_Delete = await GetByIdAsync(id, cancellationToken);
            _dbset.Remove(Entity_To_Delete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<TEntity>> ToList()
        {
            return await _dbset.ToListAsync();
        }

    }
}