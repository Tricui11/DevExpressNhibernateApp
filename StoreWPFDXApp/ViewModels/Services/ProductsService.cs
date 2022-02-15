using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels.Services {
  class ProductsService : IProductsService {
    private readonly IProductRepository _productRepository;

    public ProductsService(IProductRepository productRepository) {
      _productRepository = productRepository;
    }
  }
}
