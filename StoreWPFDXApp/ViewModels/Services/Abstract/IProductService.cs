using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface IProductService {
    Task<Guid> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid uuId);
  }
}
