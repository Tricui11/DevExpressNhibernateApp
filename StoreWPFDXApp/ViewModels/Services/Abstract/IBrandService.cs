using System;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface IBrandService {
    Task<Guid> CreateAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    Task DeleteAsync(Guid uuId);
  }
}