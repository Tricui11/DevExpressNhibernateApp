using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;
using Category = StoreWPFDXApp.Models.Category;

namespace StoreWPFDXApp.ViewModels.Services {
  class CategoryService : ICategoryService {
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) {
      _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllAsync() {
      var data = await _categoryRepository.GetAllAsync();
      return data;
    }

    public async Task<Guid> CreateAsync(Category model) {
      var uuId = await _categoryRepository.AddAsync(model);
      return uuId;
    }

    public async Task UpdateAsync(Category model) {
      await _categoryRepository.UpdateAsync(model);
    }

    public async Task UpdateParentAsync(Guid entityUuId, Guid parentUuId) {
      await _categoryRepository.UpdateParentAsync(entityUuId, parentUuId);
    }

    public async Task DeleteAsync(IEnumerable<Guid> uuIds) {
      await _categoryRepository.DeleteAsync(uuIds);
    }
  }
}
