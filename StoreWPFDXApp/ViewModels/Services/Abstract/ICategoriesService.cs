using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Categories = StoreWPFDXApp.Models.Categories;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface ICategoriesService {
    Task<IEnumerable<Categories>> GetAllAsync();
    Task<Guid> CreateAsync(Categories model);
    Task UpdateAsync(Categories model);
    Task UpdateParentAsync(Guid entityUuId, Guid parentUuId);
    Task DeleteAsync(IEnumerable<Guid> uuIds);
  }
}
