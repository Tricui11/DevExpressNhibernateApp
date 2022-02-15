using System.Threading.Tasks;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels.Services {
  class BrandsService : IBrandsService {
    private readonly IBrandRepository _brandRepository;

    public BrandsService(IBrandRepository brandRepository) {
      _brandRepository = brandRepository;
    }

    public async Task<int> CreateAsync(Brands brand) {
      var id = await _brandRepository.AddAsync(brand);
      return id;
    }
    public async Task UpdateAsync(Brands brand) {
      await _brandRepository.UpdateAsync(brand);
    }
    public async Task DeleteAsync(int id) {
      await _brandRepository.DeleteAsync(id);
    }
  }
}
