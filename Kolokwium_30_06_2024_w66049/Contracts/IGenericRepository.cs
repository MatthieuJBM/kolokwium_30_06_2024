namespace Kolokwium_30_06_2024_w66049.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(int? id);

    Task<List<T>> GetAllAsync();

    Task<T> AddAsync(T entity);

    Task DeleteAsync(int id);

    Task UpdateAsync(T entity);

    Task<bool> Exists(int id);
}