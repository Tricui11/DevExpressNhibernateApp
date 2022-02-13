using System.Collections.Generic;
using System.Threading.Tasks;
using Categories = StoreWPFDXApp.Data.Categories;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface ICategoriesService {
    Task<IEnumerable<Categories>> GetAllAsync();
  }
}
