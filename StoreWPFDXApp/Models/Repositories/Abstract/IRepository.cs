using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface IRepository<T> {

    //  T Add(T entity);
    Task<IEnumerable<T>> GetAllAsync();

    //Task<T> FindAsync(params object[] keyValues);

    //Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool trackEntity = false);

    //void Update(T entity);
    //void Delete(T entity);
    //Task<bool> IsExistingAsync(int id);
  }
}
