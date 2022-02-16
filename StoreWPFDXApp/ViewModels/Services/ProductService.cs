using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels.Services {
  class ProductService : IProductService {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) {
      _productRepository = productRepository;
    }

    public async Task<Guid> CreateAsync(Product product) {
      var uuId = await _productRepository.AddAsync(product);
      return uuId;
    }

    public async Task DeleteAsync(Guid uuId) {
      await _productRepository.DeleteAsync(uuId);
    }

    public async Task UpdateAsync(Product product) {
      await _productRepository.UpdateAsync(product);
    }
  }
}
