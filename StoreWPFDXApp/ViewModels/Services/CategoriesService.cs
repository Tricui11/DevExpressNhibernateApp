using System.Collections.Generic;
using System.Threading.Tasks;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;
using Categories = StoreWPFDXApp.Data.Categories;

namespace StoreWPFDXApp.ViewModels.Services {
  class CategoriesService : ICategoriesService {
    private readonly ICategoryRepository _categoryRepository;


    public CategoriesService(ICategoryRepository categoryRepository) {
      _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() {
      var data = await _categoryRepository.GetAllAsync();
      return data;
    }
  }
}
