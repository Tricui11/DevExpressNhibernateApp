using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface IProductsService {
    Task<Guid> CreateAsync(Products product);
    Task UpdateAsync(Products product);
    Task DeleteAsync(Guid uuId);
  }
}
