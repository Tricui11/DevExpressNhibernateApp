using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface IRepository<T> {
    Task<Guid> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid uuId);
  }
}
