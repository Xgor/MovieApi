namespace Movie.Core.Contracts;

public interface IRepositoryBase<T> where T : class
{
    void Create(T entity);
    void Delete(T entity);
    void Update(T entity);
}