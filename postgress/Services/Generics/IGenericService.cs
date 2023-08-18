using System.Linq.Expressions;
using System.Security.Principal;
using postgress.Entities;

namespace postgress.Services.Generics;

public interface IGenericService<T> where T : class, IEntity
{
    Task<List<T>> GetAll();
    Task<T?> Get(Guid id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(Guid id);
}