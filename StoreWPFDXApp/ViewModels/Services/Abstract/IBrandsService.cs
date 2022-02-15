using System.Threading.Tasks;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels.Services.Abstract {
  public interface IBrandsService {
    Task<int> CreateAsync(Brands brand);
    Task UpdateAsync(Brands brand);
    Task DeleteAsync(int id);
  }
}