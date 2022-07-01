namespace Infrastructure.Repositories;

public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    private readonly AppDbContext _dbContext;

    public RepositoryAsync(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}

