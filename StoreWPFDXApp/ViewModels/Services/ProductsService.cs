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

    public async Task<int> CreateAsync(Products product) {
      var id = await _productRepository.AddAsync(product);
      return id;
    }

    public async Task DeleteAsync(int id) {
      await _productRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Products product) {
      await _productRepository.UpdateAsync(product);
    }
  }
}
