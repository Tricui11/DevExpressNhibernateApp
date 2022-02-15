using System;
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

    public async Task<Guid> CreateAsync(Brands brand) {
      var uuId = await _brandRepository.AddAsync(brand);
      return uuId;
    }
    public async Task UpdateAsync(Brands brand) {
      await _brandRepository.UpdateAsync(brand);
    }
    public async Task DeleteAsync(Guid uuId) {
      await _brandRepository.DeleteAsync(uuId);
    }
  }
}
