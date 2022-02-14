using System.Collections.Generic;
using System.Threading.Tasks;
using StoreWPFDXApp.Data;

namespace StoreWPFDXApp.Models.Repositories.Abstract {
  public interface ICategoryRepository : IRepository<Categories> {
    Task UpdateParentAsync(int entityId, int parentId);
    Task DeleteAsync(IEnumerable<int> iDs);
  }
}
