using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels.Services {
  class BrandService : IBrandService {
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository) {
      _brandRepository = brandRepository;
    }

    public async Task<Guid> CreateAsync(Brand brand) {
      var uuId = await _brandRepository.AddAsync(brand);
      return uuId;
    }
    public async Task UpdateAsync(Brand brand) {
      await _brandRepository.UpdateAsync(brand);
    }
    public async Task DeleteAsync(Guid uuId) {
      await _brandRepository.DeleteAsync(uuId);
    }
  }
}
