namespace Application.Interfaces;

public interface IRepositoryAsync<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> AddAsync(T entity);
}

