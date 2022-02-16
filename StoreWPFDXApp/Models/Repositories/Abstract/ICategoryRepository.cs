using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface ICategoryRepository : IRepository<Category> {
    Task<IEnumerable<Category>> GetAllAsync();
    Task UpdateParentAsync(Guid entityUuId, Guid parentUuId);
    Task DeleteAsync(IEnumerable<Guid> uuIds);
  }
}
