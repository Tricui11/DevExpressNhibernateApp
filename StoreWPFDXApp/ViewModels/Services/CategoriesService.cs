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

    public async Task<int> CreateAsync(Categories model) {
      var id = await _categoryRepository.AddAsync(model);
      return id;
    }

    public async Task UpdateAsync(Categories model) {
      await _categoryRepository.UpdateAsync(model);
    }

    public async Task UpdateParentAsync(int entityId, int parentId) {
      await _categoryRepository.UpdateParentAsync(entityId, parentId);
    }

    public async Task DeleteAsync(IEnumerable<int> iDs) {
      await _categoryRepository.DeleteAsync(iDs);
    }
  }
}
