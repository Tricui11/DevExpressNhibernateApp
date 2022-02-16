using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category = StoreWPFDXApp.Models.Category;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface ICategoryService {
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Guid> CreateAsync(Category model);
    Task UpdateAsync(Category model);
    Task UpdateParentAsync(Guid entityUuId, Guid parentUuId);
    Task DeleteAsync(IEnumerable<Guid> uuIds);
  }
}
