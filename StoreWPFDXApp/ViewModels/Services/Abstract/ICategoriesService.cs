using System.Collections.Generic;
using System.Threading.Tasks;
using Categories = StoreWPFDXApp.Data.Categories;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface ICategoriesService {
    Task<IEnumerable<Categories>> GetAllAsync();
    Task<int> CreateAsync(Categories model);
    Task UpdateAsync(Categories model);
    Task UpdateParentAsync(int entityId, int parentId);
    Task DeleteAsync(IEnumerable<int> iDs);
  }
}
