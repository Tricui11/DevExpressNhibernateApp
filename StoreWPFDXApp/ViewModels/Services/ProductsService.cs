using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels.Services {
  class ProductsService : IProductsService {
    private readonly IProductRepository _productRepository;

    public ProductsService(IProductRepository productRepository) {
      _productRepository = productRepository;
    }

    public async Task<Guid> CreateAsync(Products product) {
      var uuId = await _productRepository.AddAsync(product);
      return uuId;
    }

    public async Task DeleteAsync(Guid uuId) {
      await _productRepository.DeleteAsync(uuId);
    }

    public async Task UpdateAsync(Products product) {
      await _productRepository.UpdateAsync(product);
    }
  }
}
