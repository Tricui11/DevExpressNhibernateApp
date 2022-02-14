using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface IRepository<T> {
    Task<int> AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
  }
}
