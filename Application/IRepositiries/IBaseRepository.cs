namespace Application.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {


        Task DeleteAsync(int id, CancellationToken cancellationToken);

        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAllEAsync(CancellationToken cancellationToken);
        Task<List<TEntity>> ToList();
    }
}